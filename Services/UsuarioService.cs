using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;
using CitasMedicasME.Services.InterfacesService;
using CitasMedicasME.UnitOfWork;

public class UsuarioService : IUsuarioService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UsuarioDto>> ListarUsuariosAsync()
    {
        var usuarios = await _unitOfWork.Usuarios.ListarAsync();
        return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
    }

    public async Task<UsuarioDto> ObtenerUsuarioPorIdAsync(int id)
    {
        var usuario = await _unitOfWork.Usuarios.BuscarPorIdAsync(id);
        return _mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<UsuarioDto> CrearUsuarioAsync(CrearUsuarioDto usuarioDto)
    {
        var usuario = _mapper.Map<Usuario>(usuarioDto);

        usuario.Clave = usuarioDto.Clave; // Placeholder para asignación directa,( no seguro para producción )

        await _unitOfWork.Usuarios.Agregar(usuario);
        await _unitOfWork.CompleteAsync();

        var usuarioDtoCreado = _mapper.Map<UsuarioDto>(usuario);
        return usuarioDtoCreado;
    }

    public async Task ActualizarUsuarioAsync(int id, UsuarioDto usuarioDto)
    {
        //var usuario = await _unitOfWork.Usuarios.BuscarPorIdAsync(usuarioDto.Id);
        //if (usuario != null)
        //{
        //    _mapper.Map(usuarioDto, usuario);
        //    _unitOfWork.Usuarios.Actualizar(usuario);
        //    await _unitOfWork.CompleteAsync();
        //}
        // Buscar al médico por su ID
        var usuario = await _unitOfWork.Usuarios.BuscarPorIdAsync(id);
        if (usuario == null)
        {
            throw new KeyNotFoundException("No se encontró el médico con el ID especificado.");
        }

        // Mapear los datos del DTO al modelo de Medico
        _mapper.Map(usuarioDto, usuario);

        try
        {
            // Actualizar el medico en la base de datos
            _unitOfWork.Usuarios.Actualizar(usuario);

            // Guardar los cambios en la base de datos
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception ex)
        {
            // Logear la excepción...
            throw new Exception("Ocurrió un error al intentar actualizar el médico.", ex);
        }
    }

    public async Task<bool> EliminarUsuarioAsync(int id)
    {
        var exito = await _unitOfWork.Usuarios.EliminarAsync(id);
        if (exito)
        {
            await _unitOfWork.CompleteAsync();
            return true;
        }
        return false;
    }
    public async Task<UsuarioDto> AutenticarUsuarioAsync(loginDto usuarioDto)
    {
        var usuarioEncontrado = await _unitOfWork.Usuarios.BuscarPorUsernameAsync(usuarioDto.Username);
        if (usuarioEncontrado != null)
        {
            if (usuarioEncontrado.Clave == usuarioDto.Clave) // Comparación directa, solo para aprendizaje
            {
                // Mapea el usuario encontrado a UsuarioDto para devolverlo
                var usuarioAutenticadoDto = _mapper.Map<UsuarioDto>(usuarioEncontrado);
    

            return usuarioAutenticadoDto;
            }
        }
        return null; // Autenticación fallida
    }

}


