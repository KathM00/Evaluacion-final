using Microsoft.AspNetCore.Mvc;
using ProyectoFinalTecWeb.Entities;
using ProyectoFinalTecWeb.Entities.Dtos.ModelDto;
using ProyectoFinalTecWeb.Services;

namespace ProyectoFinalTecWeb.Controllers
{
    [ApiController]
    [Route("api/model")]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _service;

        public ModelController(IModelService service)
        {
            _service = service;
        }

        // POST: api/model
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateModelDto dto)
        {
            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        // GET: api/model
        [HttpGet]
        public async Task<IActionResult> GetAllModels()
        {
            IEnumerable<Model> items = await _service.GetAll();
            return Ok(items);
        }

        // GET: api/model/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        // PUT: api/model/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateModelDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var model = await _service.UpdateAsync(dto, id);
            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }

        // DELETE: api/model/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
