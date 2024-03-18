using Microsoft.AspNetCore.Mvc;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Services;
using System.Threading.Tasks;

namespace CitasMedicasME.Controllers
{
    [ApiController]
    [Route("medicos")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicosController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarMedicos()
        {
            var medicos = await _medicoService.ListarMedicosAsync();
            return Ok(medicos);
        }

        [HttpGet("buscarPorId/{id}")]
        public async Task<IActionResult> BuscarMedicoPorId(int id)
        {
            var medicoDto = await _medicoService.ObtenerMedicoPorIdAsync(id);
            if (medicoDto == null)
            {
                return NotFound();
            }
            return Ok(medicoDto);
        }

        // GET: /medicos/buscar/{numColegiado}
        [HttpGet("buscarPorNum/{numColegiado}")]
        public async Task<IActionResult> BuscarMedicoPorNumColegiado(string numColegiado)
        {
            var medicoDto = await _medicoService.ObtenerMedicoPorNumColegiadoAsync(numColegiado);
            if (medicoDto == null)
            {
                return NotFound();
            }
            return Ok(medicoDto);
        }

        // POST: /medicos/crear
        [HttpPost("crear")]
        public async Task<IActionResult> CrearMedico([FromBody] CrearMedicoDto crearMedicoDto)
        {
            var creadoMedicoDto = await _medicoService.CrearMedicoAsync(crearMedicoDto);
            if (creadoMedicoDto == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(BuscarMedicoPorNumColegiado), new { numColegiado = creadoMedicoDto.NumColegiado }, creadoMedicoDto);
        }


        // PUT: /medicos/actualizar/{id}
        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> ActualizarMedico(int id, [FromBody] EditarMedicoDto medicoDto)
        {
            try
            {
                await _medicoService.ActualizarMedicoAsync(id, medicoDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        
        }



        // DELETE: /medicos/eliminar/{numColegiado}
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarMedico(int id)
        {
            await _medicoService.EliminarMedicoAsync(id);
            return NoContent();
        }
    }
}
