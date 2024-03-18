using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;
using CitasMedicasME.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitasMedicasME.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PacienteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PacienteDto>> ListarPacientesAsync()
        {
            var paciente = await _unitOfWork.Pacientes.ListarAsync();
            return _mapper.Map<IEnumerable<PacienteDto>>(paciente);
        }

        public async Task<PacienteDto> ObtenerPacientePorIdAsync(int id)
        {
            var paciente = await _unitOfWork.Pacientes.BuscarPorIdAsync(id);
            return paciente != null ? _mapper.Map<PacienteDto>(paciente) : null;
        }

        public async Task<PacienteDto> CrearPacienteAsync(CrearPacienteDto crearPacienteDto)
        {
            var paciente = _mapper.Map<Paciente>(crearPacienteDto);
            await _unitOfWork.Pacientes.Agregar(paciente);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<PacienteDto>(paciente);
        }
        public async Task ActualizarPacienteAsync(int id, EditarPacienteDto editarPacienteDto)
        {
            var paciente = await _unitOfWork.Pacientes.BuscarPorIdAsync(id);
            if (paciente != null)
            {
                _mapper.Map(editarPacienteDto, paciente);
                await _unitOfWork.Pacientes.Actualizar(paciente);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task EliminarPacienteAsync(int id)
        {
            await _unitOfWork.Pacientes.EliminarAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public Task ActualizarPacienteAsync(PacienteDto pacienteDto)
        {
            throw new NotImplementedException();
        }
    }
}
