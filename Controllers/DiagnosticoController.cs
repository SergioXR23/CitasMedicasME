using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.DTOs.CitasMedicasME.Models.DTOs;
using CitasMedicasME.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitasMedicasME.Controllers
{
    [ApiController]
    [Route("diagnosticos")]
    public class DiagnosticoController : ControllerBase
    {
        private readonly IDiagnosticoService _diagnosticoService;
        private readonly IMapper _mapper;

        public DiagnosticoController(IDiagnosticoService diagnosticoService, IMapper mapper)
        {
            _diagnosticoService = diagnosticoService;
            _mapper = mapper;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<DiagnosticoDto>>> ListarDiagnosticos()
        {
            var diagnosticos = await _diagnosticoService.ListarDiagnosticosAsync();
            return Ok(diagnosticos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<DiagnosticoDto>> ObtenerDiagnosticoPorId(int id)
        {
            var diagnostico = await _diagnosticoService.ObtenerDiagnosticoPorIdAsync(id);
            if (diagnostico == null)
            {
                return NotFound();
            }
            return diagnostico;
        }

        [HttpPost("crear/{citaId}")]
        public async Task<IActionResult> CrearDiagnostico(int citaId, CrearDiagnosticoDto crearDiagnosticoDto)
        {
            var nuevoDiagnostico = await _diagnosticoService.CrearDiagnosticoAsync(citaId, crearDiagnosticoDto);
            if (nuevoDiagnostico == null)
            {
                return NotFound(); // O cualquier otro resultado que desees devolver si la creación falla
            }
            return CreatedAtAction(nameof(ObtenerDiagnosticoPorId), new { id = nuevoDiagnostico.Id }, nuevoDiagnostico);
        }

        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> ActualizarDiagnostico(int id, EditarDiagnosticoDto editarDiagnosticoDto)
        {
            var actualizado = await _diagnosticoService.ActualizarDiagnosticoAsync(id, editarDiagnosticoDto);
            if (!actualizado)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("borrar/{id}")]
        public async Task<IActionResult> EliminarDiagnostico(int id)
        {
            var eliminado = await _diagnosticoService.EliminarDiagnosticoAsync(id);
            if (!eliminado)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
