using CitasMedicasME.Data;
using CitasMedicasME.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using CitasMedicasME.Repositorys.InterfacesRepository;

namespace CitasMedicasME.Repositorys
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CitasMedicasContext _context;

        public UsuarioRepository(CitasMedicasContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ListarAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> BuscarPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public Task Agregar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            return Task.CompletedTask;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;
            _context.Usuarios.Remove(usuario);
            // No llamar a SaveChanges aquí, eso se manejará en la unidad de trabajo
            return true;
        }

        public void Actualizar(Usuario usuario)
        {
            // Si el usuario ya está siendo rastreado, entonces los cambios serán aplicados automáticamente.
            // Por tanto, solo necesitas asegurarte de que el usuario se encuentre adjunto al contexto.
            _context.Usuarios.Update(usuario);
            // No necesitas llamar a SaveChanges aquí. Esto se manejará en la UnitOfWork.            
        }
        public async Task<Usuario> BuscarPorUsernameAsync(string username)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
        }


    }
}

