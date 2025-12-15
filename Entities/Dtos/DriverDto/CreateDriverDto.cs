using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Entities.Dtos.DriverDto
{
    public class CreateDriverDto
    {
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; init; } = string.Empty;
        [Required]
        public string Licence { get; set; } = default!;
        [Required]
        public string Phone { get; set; } = default!;
        [Required]
        public string Role { get; set; } = "Driver";
    }
}
