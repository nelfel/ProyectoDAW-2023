using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindMeJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilProfesionalController : ControllerBase
    {
        private readonly IPerfilProfesionalRepository _perfilProfesionalRepository;

        public PerfilProfesionalController(IPerfilProfesionalRepository perfilProfesionalRepository)
        {
            _perfilProfesionalRepository = perfilProfesionalRepository;
        }

        // GET: api/PerfilProfesional
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfilProfesional>>> GetAll()
        {
            var result = await _perfilProfesionalRepository.GetAll();
            return Ok(result);
        }

        // GET: api/PerfilProfesional/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PerfilProfesional>> GetById(int id)
        {
            var result = await _perfilProfesionalRepository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // PUT: api/PerfilProfesional/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Update(PerfilProfesional perfilProfesional)
        {
            var result = await _perfilProfesionalRepository.Update(perfilProfesional);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        // POST: api/PerfilProfesional
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PerfilProfesional>> Insert(PerfilProfesional perfilProfesional)
        {
            var result = await _perfilProfesionalRepository.Insert(perfilProfesional);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE: api/PerfilProfesional/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _perfilProfesionalRepository.Delete(id);
            if (!result)
                return NotFound(result);
            return Ok(result);
        }

        // GET: GetPerfilProfesionalByDescripcion
        [HttpGet("GetPerfilProfesionalByDescripcion")]
        public async Task<ActionResult<IEnumerable<PerfilProfesional>>> GetPerfilProfesionalByDescripcion([FromQuery] string descripcion)
        {
            var result = await _perfilProfesionalRepository.GetPerfilProfesionalByDescripcion(descripcion);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
