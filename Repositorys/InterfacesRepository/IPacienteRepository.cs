using CitasMedicasME.Models.Entitys;

namespace CitasMedicasME.Repositorys.InterfacesRepository
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> ListarAsync();

        Task<Paciente> BuscarPorIdAsync(int id);
        Task Agregar(Paciente paciente);
        Task EliminarAsync(int id);
        Task Actualizar(Paciente paciente);
        Task<Paciente> BuscarPorUsernameAsync(string username);

    }
}
