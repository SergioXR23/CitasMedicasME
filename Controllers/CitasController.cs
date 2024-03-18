using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Services.InterfacesService;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("citas")]
public class CitasController : ControllerBase
{
    private readonly ICitaService _citaService;

    public CitasController(ICitaService citaService)
    {
        _citaService = citaService;
    }

    [HttpGet("listar")]
    public async Task<IActionResult> ListarTodasLasCitas()
    {
        var citasDto = await _citaService.ListarCitasAsync();
        return Ok(citasDto);
    }

    [HttpGet("buscar/{id}")]
    public async Task<IActionResult> ObtenerCitaPorId(int id)
    {
        var citaDto = await _citaService.ObtenerCitaPorIdAsync(id);
        if (citaDto == null)
        {
            return NotFound();
        }
        return Ok(citaDto);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> CrearCita([FromBody] CrearCitaDto crearCitaDto)
    {
        var citaDto = await _citaService.CrearCitaAsync(crearCitaDto);
        return CreatedAtAction(nameof(ObtenerCitaPorId), new { id = citaDto.Id }, citaDto);
    }

    [HttpPut("actualizar/{id}")]
    public async Task<IActionResult> ActualizarCita(int id, [FromBody] EditarCitaDto editarCitaDto)
    {
        var resultado = await _citaService.ActualizarCitaAsync(id, editarCitaDto);
        if (!resultado)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("eliminar/{id}")]
    public async Task<IActionResult> EliminarCita(int id)
    {
        var resultado = await _citaService.EliminarCitaAsync(id);
        if (!resultado)
        {
            return NotFound();
        }
        return NoContent();
    }
}
