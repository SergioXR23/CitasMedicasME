using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;

namespace CitasMedicasME.Profiles
{
    public class CitaMappingProfile : Profile
    {
        public CitaMappingProfile()
        {
            // Mapeo de la entidad Cita a CitaDto y viceversa
            CreateMap<Cita, CitaDto>();
            CreateMap<CitaDto, Cita>();

            // Mapeo de CrearCitaDto a Cita (normalmente no se mapea en la dirección inversa)
            CreateMap<CrearCitaDto, Cita>();

            // Si tienes un DTO para actualizar citas, sería algo así
            CreateMap<EditarCitaDto, Cita>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); // Ignora el Id para evitar sobreescritura
        }
    }
}
