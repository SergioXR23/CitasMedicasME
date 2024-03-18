using CitasMedicasME.Repositorys.InterfacesRepository;

namespace CitasMedicasME.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUsuarioRepository Usuarios { get; }
        IPacienteRepository Pacientes { get; }
        IMedicoRepository Medicos { get; }

        Task<int> CompleteAsync(); // Guarda los cambios en la base de datos
        void Dispose(); // Libera los recursos que se están utilizando
        

    }
}
