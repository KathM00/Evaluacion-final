using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using ProyectoFinalTecWeb.Data;
using ProyectoFinalTecWeb.Repositories;
using ProyectoFinalTecWeb.Services;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Puerto para Railway
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Servicios básicos
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// JWT - Versión simplificada y segura
var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
    ?? "DefaultKeyForDevelopment1234567890ABCDEFGH=="; // Clave por defecto para desarrollo

var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "TaxiApi";
var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "TaxiClient";

// Usar UTF8 en lugar de Base64 para evitar el error
var keyBytes = Encoding.UTF8.GetBytes(jwtKey.PadRight(32, '=')[..32]); // Asegurar 32 bytes

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ClockSkew = TimeSpan.Zero
        };
    });

// Base de datos
var connectionString = GetConnectionString();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

// Registrar servicios (mantener tus registros actuales)
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();

builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDriverVehicleService, DriverVehicleService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

// Migraciones
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapControllers();
app.Run();

string GetConnectionString()
{
    var railwayUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

    if (!string.IsNullOrEmpty(railwayUrl))
    {
        var uri = new Uri(railwayUrl);
        var userInfo = uri.UserInfo.Split(':');

        return new NpgsqlConnectionStringBuilder
        {
            Host = uri.Host,
            Port = uri.Port,
            Database = uri.AbsolutePath.Trim('/'),
            Username = Uri.UnescapeDataString(userInfo[0]),
            Password = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : "",
            SslMode = SslMode.Require,
            TrustServerCertificate = true
        }.ToString();
    }

    // Fallback para desarrollo local
    return builder.Configuration.GetConnectionString("Default")
        ?? "Host=localhost;Database=TaxiDB;Username=postgres;Password=postgres";
}