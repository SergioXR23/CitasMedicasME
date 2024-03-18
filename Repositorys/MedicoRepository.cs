using CitasMedicasME.Data;
using CitasMedicasME.Models.Entitys;
using CitasMedicasME.Repositorys.InterfacesRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitasMedicasME.Repositorys
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly CitasMedicasContext _context;

        public MedicoRepository(CitasMedicasContext context)
        {
            _context = context;
        }
        public async Task Actualizar(Medico medico)
        {
            _context.Entry(medico).State = EntityState.Modified;
            // No se llama a SaveChanges aquí si se hace en el UnitOfWork 
        }

        public async Task Agregar(Medico medico)
        {
            _context.Medicos.Add(medico);
        }

        public async Task<Medico> BuscarPorIdAsync(int id)
        {
            return await _context.Medicos.FindAsync(id);
        }

        public async Task<Medico> BuscarPorNumColegiadoAsync(string numColegiado)
        {
            return await _context.Medicos.FirstOrDefaultAsync(m => m.NumColegiado == numColegiado);
        }

        public async Task EliminarAsync(int id)
        {
            // Encuentra al médico por su ID.
            var medico = await _context.Medicos.FindAsync(id);
            if (medico != null)
            {
                // Elimina al médico del contexto y guarda los cambios.
                _context.Medicos.Remove(medico);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Opcionalmente, podrías manejar el caso cuando el médico no existe.
                throw new InvalidOperationException("No se puede eliminar un médico que no existe.");
            }
        }
        public async Task<IEnumerable<Medico>> ListarAsync()
        {
           return await _context.Medicos.ToListAsync();
        }
    }
}
