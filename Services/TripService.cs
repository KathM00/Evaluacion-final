using ProyectoFinalTecWeb.Entities;
using ProyectoFinalTecWeb.Entities.Dtos.TripDto;
using ProyectoFinalTecWeb.Repositories;

namespace ProyectoFinalTecWeb.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _trips;
        private readonly IDriverRepository _drivers;
        private readonly IPassengerRepository _passengers;

        public TripService(ITripRepository trips, IDriverRepository conductor, IPassengerRepository pasajero)
        {
            _trips = trips;
            _drivers = conductor;
            _passengers = pasajero;
        }
        public async Task<Guid> CreateAsync(CreateTripDto dto)
        {
            // Cargar Passenger y Driver CON SUS TRIPS
            var passenger = await _passengers.GetByIdWithTripsAsync(dto.PassengerId);
            var driver = await _drivers.GetByIdWithTripsAsync(dto.DriverId);

            if (passenger == null || driver == null)
                throw new Exception("Passenger or Driver not found");

            // Crear trip
            var trip = new Trip
            {
                Id = Guid.NewGuid(),
                Origin = dto.Origin,
                Destiny = dto.Destiny,
                Price = dto.Price,
                StartDate = DateTime.SpecifyKind(dto.StartDate, DateTimeKind.Utc),
                EndDate = DateTime.SpecifyKind(dto.EndDate, DateTimeKind.Utc),
                PassengerId = dto.PassengerId,
                DriverId = dto.DriverId,
                Passenger = passenger,
                Driver = driver
            };

            // Actualizar colecciones
            passenger.Trips.Add(trip);
            driver.Trips.Add(trip);

            await _trips.AddAsync(trip);
            await _trips.SaveChangesAsync();

            return trip.Id;
        }

        public async Task<IEnumerable<Trip>> GetAllAsync()
        {
            return await _trips.GetAllAsync();
        }

        public async Task<Trip?> GetByIdAsync(Guid id)
        {
            return await _trips.GetTripAsync(id);
        }
    }
}
