using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.DTOs.CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;

namespace CitasMedicasME.Profiles
{
    public class DiagnosticoMappingProfile : Profile
    {
        public DiagnosticoMappingProfile()
        {
            CreateMap<Diagnostico, DiagnosticoDto>();
            CreateMap<CrearDiagnosticoDto, Diagnostico>();
            CreateMap<EditarDiagnosticoDto, Diagnostico>();
        }
    }
}
