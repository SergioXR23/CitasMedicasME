using CitasMedicasME.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitasMedicasME.Services
{
    public interface IMedicoService
    {
        Task<IEnumerable<MedicoDto>> ListarMedicosAsync();
        Task<MedicoDto> ObtenerMedicoPorIdAsync(int id);
        Task<MedicoDto> ObtenerMedicoPorNumColegiadoAsync(string numColegiado);
        Task<MedicoDto> CrearMedicoAsync(CrearMedicoDto crearMedicoDto);
        Task ActualizarMedicoAsync(int id, EditarMedicoDto medicoDto);
        Task EliminarMedicoAsync(int id);
    }
}
