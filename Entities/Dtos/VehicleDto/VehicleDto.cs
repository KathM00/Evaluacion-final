using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Entities.Dtos.VehicleDto
{
    public class VehicleDto
    {
        public Guid Id { get; set; }
        public string Plate { get; set; } = default!;
        public Guid ModelId { get; set; } = default!;

        // Solo información básica del Model, sin incluir Vehicle
        public ModelInfoDto Model { get; set; } = default!;

        // Drivers (si necesitas)
        public List<DriverInfoDto> Drivers { get; set; } = new();
    }

    public class ModelInfoDto
    {
        public Guid Id { get; set; }
        public string Brand { get; set; } = default!;
        public int Year { get; set; }
    }

    public class DriverInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = string.Empty;
        public string Licence { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Role { get; set; } = "Driver";

    }
}
