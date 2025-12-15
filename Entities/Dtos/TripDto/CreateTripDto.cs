using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Entities.Dtos.TripDto
{
    public class CreateTripDto
    {
        [Required]
        public string Origin { get; set; } = string.Empty;
        [Required]
        public string Destiny { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public Guid PassengerId { get; set; }
        [Required]
        public Guid DriverId { get; set; }

    }
}
