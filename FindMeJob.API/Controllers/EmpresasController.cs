using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FindMeJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresasController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetAll()
        {
            var result = await _empresaRepository.GetAll();
            return Ok(result);
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetById(int id)
        {
            var result = await _empresaRepository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // PUT: api/Empresas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> Update(Empresa empresa)
        {
            var result = await _empresaRepository.Update(empresa);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        // POST: api/Empresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empresa>> Insert(Empresa empresa)
        {
            var result = await _empresaRepository.Insert(empresa);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _empresaRepository.Delete(id);
            if (!result)
                return NotFound(result);
            return Ok(result);
        }
    }
}
