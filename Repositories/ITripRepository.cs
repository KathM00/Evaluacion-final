using ProyectoFinalTecWeb.Entities;

namespace ProyectoFinalTecWeb.Repositories
{
    public interface ITripRepository
    {
        Task AddAsync(Trip trip);
        Task<Trip?> GetTripAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<IEnumerable<Trip>> GetAllAsync();
        Task<int> SaveChangesAsync();
    }
}
