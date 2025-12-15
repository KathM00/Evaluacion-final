using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Entities.Dtos.TripDto
{
    public class UpdateTripDto
    {
        public string Origin { get; set; } = default!;
        public string Destiny { get; set; } = default!;
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
