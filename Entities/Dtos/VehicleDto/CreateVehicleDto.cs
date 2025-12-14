using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Entities.Dtos.VehicleDto
{
    public class CreateVehicleDto
    {
        [Required]
        public Guid ModelId { get; set; }
        [Required]
        public Guid DriverId { get; set; }
        [Required]
        public string Plate { get; set; }
    }
}
