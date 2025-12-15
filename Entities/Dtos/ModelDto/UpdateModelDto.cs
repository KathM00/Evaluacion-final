using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalTecWeb.Entities.Dtos.ModelDto
{
    public class UpdateModelDto
    {
        public string Brand { get; set; } = default!;
        public int Year { get; set; }
    }
}
