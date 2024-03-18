using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;
using CitasMedicasME.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitasMedicasME.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task ActualizarMedicoAsync(int id, EditarMedicoDto medicoDto)
        {
            // Buscar al médico por su ID
            var medico = await _unitOfWork.Medicos.BuscarPorIdAsync(id);
            if (medico == null)
            {
                throw new KeyNotFoundException("No se encontró el médico con el ID especificado.");
            }

            // Mapear los datos del DTO al modelo de Medico
            _mapper.Map(medicoDto, medico);

            try
            {
                // Actualizar el medico en la base de datos
                _unitOfWork.Medicos.Actualizar(medico);

                // Guardar los cambios en la base de datos
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                // Logear la excepción...
                throw new Exception("Ocurrió un error al intentar actualizar el médico.", ex);
            }
        }

        public async Task<MedicoDto> CrearMedicoAsync(CrearMedicoDto crearMedicoDto)
        {
           var medico = _mapper.Map<Medico>(crearMedicoDto);
            await _unitOfWork.Medicos.Agregar(medico);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<MedicoDto>(medico);
        }

        public async Task EliminarMedicoAsync(int id)
        {
            await _unitOfWork.Medicos.EliminarAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<MedicoDto>> ListarMedicosAsync()
        {
           var medico = await _unitOfWork.Medicos.ListarAsync();
            return _mapper.Map<IEnumerable<MedicoDto>>(medico);
        }

        public async Task<MedicoDto> ObtenerMedicoPorIdAsync(int id)
        {
            var medico = await _unitOfWork.Medicos.BuscarPorIdAsync(id);
            return medico != null ? _mapper.Map<MedicoDto>(medico) : null;
        }

        public async Task<MedicoDto> ObtenerMedicoPorNumColegiadoAsync(string numColegiado)
        {
           var medico = await _unitOfWork.Medicos.BuscarPorNumColegiadoAsync(numColegiado);
            return medico != null ? _mapper.Map<MedicoDto>(medico) : null;
        }
    }
}
