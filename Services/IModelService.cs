using ProyectoFinalTecWeb.Entities;
using ProyectoFinalTecWeb.Entities.Dtos.ModelDto;

namespace ProyectoFinalTecWeb.Services
{
    public interface IModelService
    {
        Task<Guid> CreateAsync(CreateModelDto dto);
        Task<Model> GetByIdAsync(Guid id);
        Task<Model> UpdateAsync(UpdateModelDto dto, Guid id);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Model>> GetAll();
    }
}
