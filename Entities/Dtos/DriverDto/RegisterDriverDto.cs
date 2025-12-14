using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Entities.Dtos.DriverDto
{
    public class RegisterDriverDto
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Licence { get; set; } = default!;
        public string Phone { get; set; }
        public string Role { get; set; } = "Driver";
    }
}
