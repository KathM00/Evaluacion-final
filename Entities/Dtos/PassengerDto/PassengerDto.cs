namespace ProyectoFinalTecWeb.Entities.Dtos.PassengerDto
{
    public class PassengerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public List<TripSimpleDto> Trips { get; set; } = new();
    }

    public class TripSimpleDto
    {
        public Guid Id { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
