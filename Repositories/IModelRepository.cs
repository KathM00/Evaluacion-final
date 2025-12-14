using ProyectoFinalTecWeb.Entities;

namespace ProyectoFinalTecWeb.Repositories
{
    public interface IModelRepository
    {
        Task<bool> ExistsAsync(Guid id);
        Task<int> SaveChangesAsync();

        //CRUD
        Task AddAsync(Model model);
        Task<IEnumerable<Model>> GetAll();
        Task<Model?> GetByIdAsync(Guid id);
        Task Update(Model model);
        Task Delete(Model model);
    }
}
