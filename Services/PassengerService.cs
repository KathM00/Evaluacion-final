using ProyectoFinalTecWeb.Entities;
using ProyectoFinalTecWeb.Entities.Dtos.PassengerDto;
using ProyectoFinalTecWeb.Repositories;

namespace ProyectoFinalTecWeb.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengers;
        private readonly IConfiguration _configuration;
        public PassengerService(IPassengerRepository passengers, IConfiguration configuration)
        {
            _passengers = passengers;
            _configuration = configuration;
        }

        public async Task DeletePassenger(Guid id)
        {
            Passenger? passenger = await _passengers.GetOne(id);
            if (passenger == null) return;
            await _passengers.Delete(passenger);

        }

        public async Task<IEnumerable<PassengerDto>> GetAll()
        {
            var passengers = await _passengers.GetAllWithTripsAsync();

            return passengers.Select(p => new PassengerDto
            {
                Id = p.Id,
                Name = p.Name,
                Phone = p.Phone,
                Email = p.Email,
                Role = p.Role,
                Trips = p.Trips.Select(t => new TripSimpleDto
                {
                    Id = t.Id,
                    Origin = t.Origin,
                    Destiny = t.Destiny,
                    Price = t.Price,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate
                }).ToList()
            });
        }
        public async Task<PassengerDto> GetOne(Guid id)
        {
            var passenger = await _passengers.GetByIdWithTripsAsync(id);
            if (passenger == null) return null;

            return new PassengerDto
            {
                Id = passenger.Id,
                Name = passenger.Name,
                Phone = passenger.Phone,
                Email = passenger.Email,
                Role = passenger.Role,
                Trips = passenger.Trips.Select(t => new TripSimpleDto
                {
                    Id = t.Id,
                    Origin = t.Origin,
                    Destiny = t.Destiny,
                    Price = t.Price,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate
                }).ToList()
            };
        }
        public async Task<IEnumerable<Passenger>> GetAllNormal()
        {
            return await _passengers.GetAll();
        }

        public async Task<Passenger> GetOneNormal(Guid id)
        {
            return await _passengers.GetOne(id);
        }

        public async Task<string> RegisterAsync(RegisterPassengerDto dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var passenger = new Passenger
            {
                Email = dto.Email,
                Name = dto.Name
            };
            await _passengers.AddAsync(passenger);
            return passenger.Id.ToString();
        }
        
        public async Task<Passenger> UpdatePassenger(UpdatePassengerDto dto, Guid id)
        {
            Passenger? passenger = await GetOneNormal(id);
            if (passenger == null) throw new Exception("Passenger doesnt exist.");

            passenger.Name = dto.Name;
            passenger.Phone = dto.Phone;
            passenger.Email = dto.Email;

            await _passengers.Update(passenger);
            return passenger;
        }
    }
}
