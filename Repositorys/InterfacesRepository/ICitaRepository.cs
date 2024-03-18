using CitasMedicasME.Models.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitasMedicasME.Repositorys.InterfacesRepository
{
    public interface ICitaRepository
    {
        Task<List<Cita>> GetAllAsync();
        Task<Cita> GetByIdAsync(int id);
        Task AddAsync(Cita cita);
        Task UpdateAsync(Cita cita);
        Task DeleteAsync(Cita cita);
    }
}
