using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.DTOs.CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;
using CitasMedicasME.Repositorys.InterfacesRepository;
using CitasMedicasME.Services.Interfaces;
using System.Threading.Tasks;

namespace CitasMedicasME.Services
{
    public class DiagnosticoService : IDiagnosticoService
    {
        private readonly IDiagnosticoRepository _diagnosticoRepository;
        private readonly IMapper _mapper;

        public DiagnosticoService(IDiagnosticoRepository diagnosticoRepository, IMapper mapper)
        {
            _diagnosticoRepository = diagnosticoRepository;
            _mapper = mapper;
        }

        public async Task<DiagnosticoDto> ObtenerDiagnosticoPorIdAsync(int id)
        {
            var diagnostico = await _diagnosticoRepository.GetByIdAsync(id);
            return _mapper.Map<DiagnosticoDto>(diagnostico);
        }

        public async Task<DiagnosticoDto> CrearDiagnosticoAsync(int citaId, CrearDiagnosticoDto crearDiagnosticoDto)
        {
            var diagnostico = _mapper.Map<Diagnostico>(crearDiagnosticoDto);
            await _diagnosticoRepository.AddAsync(citaId, diagnostico);
            return _mapper.Map<DiagnosticoDto>(diagnostico);
        }

        public async Task<bool> ActualizarDiagnosticoAsync(int id, EditarDiagnosticoDto editarDiagnosticoDto)
        {
            var diagnosticoExistente = await _diagnosticoRepository.GetByIdAsync(id);
            if (diagnosticoExistente == null) return false;

            _mapper.Map(editarDiagnosticoDto, diagnosticoExistente);
            await _diagnosticoRepository.UpdateAsync(diagnosticoExistente);
            return true;
        }

        public async Task<bool> EliminarDiagnosticoAsync(int id)
        {
            var diagnostico = await _diagnosticoRepository.GetByIdAsync(id);
            if (diagnostico == null) return false;

            await _diagnosticoRepository.DeleteAsync(diagnostico);
            return true;
        }

        public async Task<IEnumerable<DiagnosticoDto>> ListarDiagnosticosAsync()
        {
            var diagnosticos = await _diagnosticoRepository.ListarAsync();
            return _mapper.Map<IEnumerable<DiagnosticoDto>>(diagnosticos);
        }

   
    }
}
