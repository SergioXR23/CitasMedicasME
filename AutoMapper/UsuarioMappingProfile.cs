using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;

public class UsuarioMappingProfile : Profile
{
    public UsuarioMappingProfile()
    {
        // =====================================================================USUARIO===================================================================== 
        // Mapeo de Usuario a UsuarioDto
        CreateMap<Usuario, UsuarioDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(ent => ent.Id))
            .ForMember(dto => dto.Nombre, opt => opt.MapFrom(ent => ent.Nombre))
            .ForMember(dto => dto.Apellidos, opt => opt.MapFrom(ent => ent.Apellidos))
            .ForMember(dto => dto.Username, opt => opt.MapFrom(ent => ent.Username));

        // Mapeo de UsuarioDto a Usuario
        CreateMap<UsuarioDto, Usuario>()
            .ForMember(ent => ent.Id, opt => opt.MapFrom(dto => dto.Id))
            .ForMember(ent => ent.Nombre, opt => opt.MapFrom(dto => dto.Nombre))
            .ForMember(ent => ent.Apellidos, opt => opt.MapFrom(dto => dto.Apellidos))
            .ForMember(ent => ent.Username, opt => opt.MapFrom(dto => dto.Username));
    }

}


