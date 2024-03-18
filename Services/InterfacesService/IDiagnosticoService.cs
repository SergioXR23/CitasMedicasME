using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.DTOs.CitasMedicasME.Models.DTOs;
using System.Threading.Tasks;

namespace CitasMedicasME.Services.Interfaces
{
    public interface IDiagnosticoService
    {
        Task<IEnumerable<DiagnosticoDto>> ListarDiagnosticosAsync();
        Task<DiagnosticoDto> ObtenerDiagnosticoPorIdAsync(int id);
        Task<DiagnosticoDto> CrearDiagnosticoAsync(int id, CrearDiagnosticoDto crearDiagnosticoDto);
        Task<bool> ActualizarDiagnosticoAsync(int id, EditarDiagnosticoDto editarDiagnosticoDto);
        Task<bool> EliminarDiagnosticoAsync(int id);
    }
}
