using CitasMedicasME.Models.DTOs;

public interface IPacienteService
{
    Task<IEnumerable<PacienteDto>> ListarPacientesAsync();
    Task<PacienteDto> ObtenerPacientePorIdAsync(int id);
    Task<PacienteDto> CrearPacienteAsync(CrearPacienteDto crearPacienteDto);
    Task ActualizarPacienteAsync(int id, EditarPacienteDto editarPacienteDto);
    Task EliminarPacienteAsync(int id);
}
