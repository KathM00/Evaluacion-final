using ProyectoFinalTecWeb.Entities.Dtos.PassengerDto;

namespace ProyectoFinalTecWeb.Entities.Dtos.DriverDto
{
    public class DriverDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Licence { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Driver";
        public List<TripSimpleDto> Trips { get; set; } = new();
        public List<VehicleSimpleDto> Vehicles { get; set; } = new();
    }

    public class VehicleSimpleDto
    {
        public Guid Id { get; set; }
        public string Plate { get; set; } = string.Empty;
        public string ModelBrand { get; set; } = string.Empty;
        public int ModelYear { get; set; }
    }
}
