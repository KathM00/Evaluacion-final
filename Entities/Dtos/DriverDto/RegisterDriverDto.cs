using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Entities.Dtos.DriverDto
{
    public class RegisterDriverDto
    {
        public string Name { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string Password { get; init; } = default!;
        public string Licence { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Role { get; set; } = "Driver";
    }
}
