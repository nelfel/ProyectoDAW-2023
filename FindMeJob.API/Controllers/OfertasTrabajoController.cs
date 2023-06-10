using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindMeJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertasTrabajoController : ControllerBase
    {
        private readonly IOfertaTrabajoRepository _ofertaTrabajoRepository;

        public OfertasTrabajoController(IOfertaTrabajoRepository ofertaTrabajoRepository)
        {
            _ofertaTrabajoRepository = ofertaTrabajoRepository;
        }

        // GET: api/OfertasTrabajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfertaTrabajo>>> GetAll()
        {
            var result = await _ofertaTrabajoRepository.GetAll();
            return Ok(result);
        }

        // GET: api/OfertasTrabajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfertaTrabajo>> GetById(int id)
        {
            var result = await _ofertaTrabajoRepository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // PUT: api/OfertasTrabajo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Update(OfertaTrabajo ofertaTrabajo)
        {
            var result = await _ofertaTrabajoRepository.Update(ofertaTrabajo);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        // POST: api/OfertasTrabajo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfertaTrabajo>> Insert(OfertaTrabajo ofertaTrabajo)
        {
            var result = await _ofertaTrabajoRepository.Insert(ofertaTrabajo);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE: api/OfertasTrabajo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _ofertaTrabajoRepository.Delete(id);
            if (!result)
                return NotFound(result);
            return Ok(result);
        }

        // GET: api/OfertasTrabajo/GetOfertasTrabajoByUsuario/5
        [HttpGet("GetByEmpresa/{id}")]
        public async Task<ActionResult<IEnumerable<OfertaTrabajo>>> GetOfertasTrabajoByUsuario(int id)
        {
            var result = await _ofertaTrabajoRepository.GetOfertasTrabajoByUsuario(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
