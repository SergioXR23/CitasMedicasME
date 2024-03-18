using System.Collections.Generic;
using AutoMapper;
using CitasMedicasME.Controllers;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;
using CitasMedicasME.Repositorys.InterfacesRepository;
using CitasMedicasME.Services.InterfacesService;

namespace CitasMedicasME.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public CitaService(ICitaRepository citaRepository, IMapper mapper)
        {
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CitaDto>> ListarCitasAsync()
        {
            var citas = await _citaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CitaDto>>(citas);
        }

        public async Task<CitaDto> ObtenerCitaPorIdAsync(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            return _mapper.Map<CitaDto>(cita);
        }

        public async Task<CitaDto> CrearCitaAsync(CrearCitaDto crearCitaDto)
        {
            var cita = _mapper.Map<Cita>(crearCitaDto);
            await _citaRepository.AddAsync(cita);
            return _mapper.Map<CitaDto>(cita);
        }

        public async Task<bool> ActualizarCitaAsync(int id, EditarCitaDto editarCitaDto)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            if (cita == null)
            {
                return false;
            }
            _mapper.Map(editarCitaDto, cita);
            await _citaRepository.UpdateAsync(cita);
            return true;
        }

        public async Task<bool> EliminarCitaAsync(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            if (cita == null)
            {
                return false;
            }
            await _citaRepository.DeleteAsync(cita);
            return true;
        }
    }

  
}
