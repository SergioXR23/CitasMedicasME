using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Services.InterfacesService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitasMedicasME.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            var usuariosDto = await _usuarioService.ListarUsuariosAsync();
            return Ok(usuariosDto);
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<UsuarioDto>> GetUsuario(int id)
        {
            var usuarioDto = await _usuarioService.ObtenerUsuarioPorIdAsync(id);
            if (usuarioDto == null)
            {
                return NotFound();
            }
            return Ok(usuarioDto);
        }

        [HttpPost("crear")]
        public async Task<ActionResult<UsuarioDto>> PostUsuario(CrearUsuarioDto usuarioDto)
        {
            var usuarioDtoCreated = await _usuarioService.CrearUsuarioAsync(usuarioDto);
            if (usuarioDtoCreated == null)
            {
                return BadRequest("No se pudo crear el usuario.");
            }
            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioDtoCreated.Id }, usuarioDtoCreated);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var success = await _usuarioService.EliminarUsuarioAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] loginDto usuarioDto)
        {
            var usuario = await _usuarioService.AutenticarUsuarioAsync(usuarioDto);
            if (usuario != null)
            {
                return Ok(usuario);
            }
            return Unauthorized(); // Retorna un error 401 si la autenticación falla
        }

        
        [HttpPut("actualizar")]
        public async Task<IActionResult> ActualizarUsuario([FromBody] int id, UsuarioDto usuarioDto) // Cambiado para recibir un objeto ActualizarUsuarioDto
        {

            try
            {
                await _usuarioService.ActualizarUsuarioAsync(id, usuarioDto);
                return NoContent(); // Retorna un 204 si la actualización es exitosa.
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"No se encontró un usuario con el ID {usuarioDto.Id}.");
            }
            catch (Exception ex)
            {
                // Manejo de errores no esperados.
                return StatusCode(500, "Ocurrió un error al procesar su solicitud: " + ex.Message);
            }
        }


    }
}
