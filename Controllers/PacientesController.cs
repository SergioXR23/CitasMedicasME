using Microsoft.AspNetCore.Mvc;
using CitasMedicasME.Services;
using CitasMedicasME.Models.DTOs;
using System.Threading.Tasks;

namespace CitasMedicasME.Controllers
{
    [ApiController]
    [Route("pacientes")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarPacientes()
        {
            var pacientes = await _pacienteService.ListarPacientesAsync();
            return Ok(pacientes);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<IActionResult> ObtenerPaciente(int id)
        {
            var paciente = await _pacienteService.ObtenerPacientePorIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPost]
        [Route("crear")]
        public async Task<IActionResult> CrearPaciente([FromBody] CrearPacienteDto crearPacienteDto)
        {
            var nuevoPaciente = await _pacienteService.CrearPacienteAsync(crearPacienteDto);
            return CreatedAtAction(nameof(ObtenerPaciente), new { id = nuevoPaciente.Id }, nuevoPaciente);
        }

        [HttpPut]
        [Route("actualizar/{id}")]
        public async Task<IActionResult> ActualizarPaciente(int id, [FromBody] EditarPacienteDto editarPacienteDto)
        {
            await _pacienteService.ActualizarPacienteAsync(id, editarPacienteDto);
            return NoContent();
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<IActionResult> EliminarPaciente(int id)
        {
            await _pacienteService.EliminarPacienteAsync(id);
            return NoContent();
        }
    }
}
