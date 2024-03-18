using CitasMedicasME.Data;
using CitasMedicasME.Models.Entitys;
using CitasMedicasME.Repositorys.InterfacesRepository;
using Microsoft.EntityFrameworkCore;

namespace CitasMedicasME.Repositorys
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly CitasMedicasContext _context;

        public PacienteRepository(CitasMedicasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> ListarAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> BuscarPorIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task<Paciente> BuscarPorUsernameAsync(string username)
        {   
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.Username == username);

        }
        public async Task Agregar(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var paciente = await BuscarPorIdAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }

}
