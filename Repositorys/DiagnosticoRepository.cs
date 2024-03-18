using CitasMedicasME.Models.Entitys;
using CitasMedicasME.Repositorys.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CitasMedicasME.Data.Repositories
{
    public class DiagnosticoRepository : IDiagnosticoRepository
    {
        private readonly CitasMedicasContext _context;

        public DiagnosticoRepository(CitasMedicasContext context)
        {
            _context = context;
        }

     

        public async Task<Diagnostico> GetByIdAsync(int id)
        {
            return await _context.Diagnosticos
                .Include(d => d.Cita)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(int citaId, Diagnostico diagnostico)
        {
            var cita = await _context.Citas.FindAsync(citaId);
            if (cita != null)
            {
                diagnostico.Cita = cita;
                _context.Diagnosticos.Add(diagnostico);
                await _context.SaveChangesAsync();
            }
            else
                throw new System.Exception("Cita no encontrada");
        }


        public async Task UpdateAsync(Diagnostico diagnostico)
        {
            _context.Entry(diagnostico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Diagnostico diagnostico)
        {
            _context.Diagnosticos.Remove(diagnostico);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Diagnostico>> ListarAsync()
        {
            return await _context.Diagnosticos.ToListAsync();

        }
    }
}
