using ProyectoFinalTecWeb.Data;
using ProyectoFinalTecWeb.Entities;
using ProyectoFinalTecWeb.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinalTecWeb.Services
{
    public class DriverVehicleService : IDriverVehicleService
    {
        private readonly AppDbContext _context;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IDriverRepository _driverRepository;

        public DriverVehicleService(
            AppDbContext context,
            IVehicleRepository vehicleRepository,
            IDriverRepository driverRepository)
        {
            _context = context;
            _vehicleRepository = vehicleRepository;
            _driverRepository = driverRepository;
        }

        public async Task AssignDriverToVehicle(Guid vehicleId, Guid driverId)
        {
            // Cargar con Includes para tener las colecciones
            var vehicle = await _context.Vehicles
                .Include(v => v.Drivers)
                .FirstOrDefaultAsync(v => v.Id == vehicleId);

            var driver = await _context.Drivers
                .Include(d => d.Vehicles)
                .FirstOrDefaultAsync(d => d.Id == driverId);

            if (vehicle == null || driver == null)
                throw new Exception("Vehicle or Driver not found");

            // Verificar si ya existe la relación
            if (!vehicle.Drivers.Any(d => d.Id == driverId))
            {
                // Agregar en AMBOS lados
                vehicle.Drivers.Add(driver);
                driver.Vehicles.Add(vehicle);

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveDriverFromVehicle(Guid vehicleId, Guid driverId)
        {
            var vehicle = await _context.Vehicles
                .Include(v => v.Drivers)
                .FirstOrDefaultAsync(v => v.Id == vehicleId);

            var driver = await _context.Drivers
                .Include(d => d.Vehicles)
                .FirstOrDefaultAsync(d => d.Id == driverId);

            if (vehicle == null || driver == null)
                throw new Exception("Vehicle or Driver not found");

            // Remover de AMBOS lados
            var driverToRemove = vehicle.Drivers.FirstOrDefault(d => d.Id == driverId);
            var vehicleToRemove = driver.Vehicles.FirstOrDefault(v => v.Id == vehicleId);

            if (driverToRemove != null)
            {
                vehicle.Drivers.Remove(driverToRemove);
                driver.Vehicles.Remove(vehicleToRemove);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesByDriver(Guid driverId)
        {
            return await _context.Drivers
                .Where(d => d.Id == driverId)
                .SelectMany(d => d.Vehicles)
                .Include(v => v.Model)
                .ToListAsync();
        }

        public async Task<IEnumerable<Driver>> GetDriversByVehicle(Guid vehicleId)
        {
            return await _context.Vehicles
                .Where(v => v.Id == vehicleId)
                .SelectMany(v => v.Drivers)
                .ToListAsync();
        }
    }
}
