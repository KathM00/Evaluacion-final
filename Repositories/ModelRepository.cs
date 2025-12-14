using Microsoft.EntityFrameworkCore;
using ProyectoFinalTecWeb.Data;
using ProyectoFinalTecWeb.Entities;

namespace ProyectoFinalTecWeb.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly AppDbContext _ctx;
        public ModelRepository(AppDbContext ctx) { _ctx = ctx; }
        public async Task AddAsync(Model model)
        {
            _ctx.Models.Add(model);
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(Model model)
        {
            _ctx.Models.Remove(model);
            await _ctx.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(Guid id) =>
            _ctx.Models.AnyAsync(s => s.Id == id);

        public async Task<IEnumerable<Model>> GetAll()
        {
            return await _ctx.Models.ToListAsync();
        }

        public Task<Model?> GetByIdAsync(Guid id) =>
            _ctx.Models.FirstOrDefaultAsync(s => s.Id == id);

        public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();

        public async Task Update(Model model)
        {
            _ctx.Models.Update(model);
            await _ctx.SaveChangesAsync();
        }
    }
}
