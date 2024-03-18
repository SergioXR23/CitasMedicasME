using CitasMedicasME.Data;
using CitasMedicasME.Data.Repositories;
using CitasMedicasME.Repositorys;
using CitasMedicasME.Repositorys.InterfacesRepository;

namespace CitasMedicasME.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CitasMedicasContext _context;
        public IUsuarioRepository Usuarios { get; private set; }
        public IPacienteRepository Pacientes { get; private set; }
        public IMedicoRepository Medicos { get; private set; }
        public IDiagnosticoRepository Diagnosticos {  get; private set; }
        public ICitaRepository Citas { get; private set; }

        public UnitOfWork(CitasMedicasContext context)
        {
            _context = context;
            Usuarios = new UsuarioRepository(_context);
            Pacientes = new PacienteRepository(_context);
            Medicos = new MedicoRepository(_context);
            Diagnosticos = new DiagnosticoRepository(_context);
            Citas = new CitaRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
