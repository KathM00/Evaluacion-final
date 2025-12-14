using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Entities.Dtos.ModelDto
{
    public class CreateModelDto
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public int Year { get; set; }
    }
}
