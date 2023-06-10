using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindMeJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostulacionesController : ControllerBase
    {

        private readonly IPostulacionRepository _postulacionRepository;

        public PostulacionesController(IPostulacionRepository postulacionRepository)
        {
            _postulacionRepository = postulacionRepository;
        }

        // GET: api/Postulaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Postulacion>>> GetAll()
        {
            var result = await _postulacionRepository.GetAll();
            return Ok(result);
        }

        // GET: api/Postulaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Postulacion>> GetById(int id)
        {
            var result = await _postulacionRepository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // PUT: api/Postulaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Update(Postulacion postulacion)
        {
            var result = await _postulacionRepository.Update(postulacion);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        // POST: api/Postulaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Postulacion>> Insert(Postulacion postulacion)
        {
            var result = await _postulacionRepository.Insert(postulacion);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE: api/Postulaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postulacionRepository.Delete(id);
            if (!result)
                return NotFound(result);
            return Ok(result);
        }

        // GET: api/Postulaciones/GetByPostulante/5
        [HttpGet("GetByPostulante/{id}")]
        public async Task<ActionResult<IEnumerable<Postulacion>>> GetByPostulante(int id)
        {
            var result = await _postulacionRepository.GetPostulacionesByUsuario(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // GET: api/Postulaciones/Usuario/5
        [HttpGet("GetByOferta/{id}")]
        public async Task<ActionResult<IEnumerable<Postulacion>>> GetByOferta(int id)
        {
            var result = await _postulacionRepository.GetPostulacionesByOfertaTrabajo(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
