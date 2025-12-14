using ProyectoFinalTecWeb.Entities;
using ProyectoFinalTecWeb.Entities.Dtos.ModelDto;
using ProyectoFinalTecWeb.Entities.Dtos.ModelDto;
using ProyectoFinalTecWeb.Repositories;

namespace ProyectoFinalTecWeb.Services
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _models;

        public ModelService(IModelRepository models)
        {
            _models = models;
        }
        public async Task<Guid> CreateAsync(CreateModelDto dto)
        {
            var entity = new Model { Brand = dto.Brand, Year = dto.Year };
            await _models.AddAsync(entity);
            await _models.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            Model? model = (await GetAll()).FirstOrDefault(h => h.Id == id);
            if (model == null) return;
            await _models.Delete(model);
        }

        public async Task<IEnumerable<Model>> GetAll()
        {
            return await _models.GetAll();
        }

        public async Task<Model> GetByIdAsync(Guid id)
        {
            return await _models.GetByIdAsync(id);
        }

        public async Task<Model> UpdateAsync(UpdateModelDto dto, Guid id)
        {
            Model? model = await GetByIdAsync(id);
            if (model == null) throw new Exception("Model doesnt exist.");

            model.Brand = dto.Brand;
            model.Year = dto.Year;

            await _models.Update(model);
            return model;
        }
    }
}
