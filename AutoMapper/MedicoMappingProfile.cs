using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;

namespace CitasMedicasME.Profiles
{
    public class MedicoMappingProfile : Profile
    {
        public MedicoMappingProfile()
        {
            // Mapeo base de Usuario a UsuarioDto
            CreateMap<Usuario, UsuarioDto>();
            // Mapeo de UsuarioDto a Usuario
            CreateMap<UsuarioDto, Usuario>();
            // Mapeo desde CrearUsuarioDto a Usuario
            CreateMap<CrearUsuarioDto, Usuario>();
            // Mapeo desde la entidad Medico a MedicoDto.
            // Automapper mapeará las propiedades de UsuarioDto automáticamente debido a la herencia.
            CreateMap<Medico, MedicoDto>();
            // Mapeo desde MedicoDto a Medico
            CreateMap<MedicoDto, Medico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.NumColegiado, opt => opt.Ignore());
            // Mapeo desde CrearMedicoDto a la entidad Medico.
            CreateMap<CrearMedicoDto, Medico>();
            // Mapeo desde EditarMedicoDto a Medico
            CreateMap<EditarMedicoDto, Medico>();
        }
    }
}
