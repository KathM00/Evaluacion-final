using ProyectoFinalTecWeb.Entities;
using ProyectoFinalTecWeb.Entities.Dtos.TripDto;

namespace ProyectoFinalTecWeb.Services
{
    public interface ITripService
    {
        Task<Guid> CreateAsync(CreateTripDto dto);

        Task<Trip?> GetByIdAsync(Guid id);
        Task<IEnumerable<Trip>> GetAllAsync();

        //Task<ViajePasajeroDto?> GetPasajeroAsync(int id);
    }
}
