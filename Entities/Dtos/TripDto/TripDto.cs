namespace ProyectoFinalTecWeb.Entities.Dtos.TripDto
{
    public class TripDto
    {
        public Guid Id { get; set; }
        public string Origin { get; set; } = default!;
        public string Destiny { get; set; } = default!;
        public int Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Información básica del Passenger
        public PassengerInfoDto Passenger { get; set; } = default!;

        // Información básica del Driver
        public DriverInfoDto Driver { get; set; } = default!;
    }

    public class PassengerInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
    }

    public class DriverInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Licence { get; set; } = default!;
    }
}
