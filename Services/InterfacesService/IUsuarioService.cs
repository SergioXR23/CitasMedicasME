using CitasMedicasME.Models.DTOs;

namespace CitasMedicasME.Services.InterfacesService
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> ListarUsuariosAsync();
        Task<UsuarioDto> ObtenerUsuarioPorIdAsync(int id);
        Task<UsuarioDto> CrearUsuarioAsync(CrearUsuarioDto usuarioDto);
        Task ActualizarUsuarioAsync(int id, UsuarioDto usuarioDto);
        Task<bool> EliminarUsuarioAsync(int id);
        // Otros métodos relacionados con la lógica de negocio podrían ser:
        //Task<IEnumerable<CitaDto>> ObtenerCitasPorUsuarioIdAsync(int usuarioId);
        //// Métodos relacionados con la autenticación de usuarios:
        Task<UsuarioDto> AutenticarUsuarioAsync(loginDto usuarioDto);

    }
}
