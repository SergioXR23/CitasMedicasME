using CitasMedicasME.Models.Entitys;
using System.Threading.Tasks;

namespace CitasMedicasME.Repositorys.InterfacesRepository
{
    public interface IDiagnosticoRepository
    {
        Task<IEnumerable<Diagnostico>> ListarAsync();
        Task<Diagnostico> GetByIdAsync(int id);
        Task AddAsync(int citaId, Diagnostico diagnostico);


        Task UpdateAsync(Diagnostico diagnostico);
        Task DeleteAsync(Diagnostico diagnostico);
    }
}
