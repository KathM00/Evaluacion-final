namespace ProyectoFinalTecWeb.Entities.Dtos.PassengerDto
{
    public class PassengerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = default!;
        public string Role { get; set; } = default!;
        public List<TripSimpleDto> Trips { get; set; } = new();
    }

    public class TripSimpleDto
    {
        public Guid Id { get; set; }
        public string Origin { get; set; } = default!;
        public string Destiny { get; set; } = default!;
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
