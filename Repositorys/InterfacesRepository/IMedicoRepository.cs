using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;

namespace CitasMedicasME.Repositorys.InterfacesRepository
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> ListarAsync();
        Task<Medico> BuscarPorIdAsync(int id);
        Task Agregar(Medico medico);
        Task EliminarAsync(int id);
        Task Actualizar(Medico medico);
        Task<Medico> BuscarPorNumColegiadoAsync(string numColegiado);
    }

}