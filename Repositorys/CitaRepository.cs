using CitasMedicasME.Models.Entitys;
using CitasMedicasME.Repositorys.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitasMedicasME.Data.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly CitasMedicasContext _context;

        public CitaRepository(CitasMedicasContext context)
        {
            _context = context;
        }

        public async Task<List<Cita>> GetAllAsync()
        {
            return await _context.Citas.ToListAsync();
        }

        public async Task<Cita> GetByIdAsync(int id)
        {
            return await _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cita cita)
        {
            _context.Entry(cita).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cita cita)
        {
            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
        }
    }
}
