using CitasMedicasME.Models.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitasMedicasME.Repositorys.InterfacesRepository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ListarAsync();
        Task<Usuario> BuscarPorIdAsync(int id);
        Task Agregar(Usuario usuario);
        Task<bool> EliminarAsync(int id);
        void Actualizar(Usuario usuario); // Método sincrónico, ya que EF Core rastrea los cambios en la entidad
        Task<Usuario> BuscarPorUsernameAsync(string username);
    }


}
