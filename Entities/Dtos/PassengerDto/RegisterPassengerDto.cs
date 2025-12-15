namespace ProyectoFinalTecWeb.Entities.Dtos.PassengerDto
{
    public class RegisterPassengerDto
    {
        public string Name { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string Password { get; init; } = default!;
        public string Phone { get; set; } = default!;
        public string Role { get; set; } = "Passenger";
    }
}
