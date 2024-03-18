using CitasMedicasME.Models.DTOs;

namespace CitasMedicasME.Services.InterfacesService
{
    public interface ICitaService
    {
        Task<IEnumerable<CitaDto>> ListarCitasAsync();
        Task<CitaDto> ObtenerCitaPorIdAsync(int id);
        Task<CitaDto> CrearCitaAsync(CrearCitaDto crearCitaDto);
        Task<bool> ActualizarCitaAsync(int id, EditarCitaDto editarCitaDto);
        Task<bool> EliminarCitaAsync(int id);
    }
}
