using AutoMapper;
using CitasMedicasME.Models.DTOs;
using CitasMedicasME.Models.Entitys;

public class PacienteMappingProfile : Profile
{
    public PacienteMappingProfile()
    {
        // Mapeo de Paciente a PacienteDto
        CreateMap<Paciente, PacienteDto>()
            .ForMember(dto => dto.Id, opt => opt.MapFrom(ent => ent.Id))
            .ForMember(dto => dto.NSS, opt => opt.MapFrom(ent => ent.NSS))
            .ForMember(dto => dto.NumTarjeta, opt => opt.MapFrom(ent => ent.NumTarjeta))
            .ForMember(dto => dto.Telefono, opt => opt.MapFrom(ent => ent.Telefono))
            .ForMember(dto => dto.Direccion, opt => opt.MapFrom(ent => ent.Direccion));

        // Mapeo de CrearPacienteDto a Paciente
        CreateMap<CrearPacienteDto, Paciente>()
            .ForMember(ent => ent.Id, opt => opt.Ignore()) // Ignoramos el Id al crear.
            .ForMember(ent => ent.NSS, opt => opt.MapFrom(dto => dto.NSS))
            .ForMember(ent => ent.NumTarjeta, opt => opt.MapFrom(dto => dto.NumTarjeta))
            .ForMember(ent => ent.Telefono, opt => opt.MapFrom(dto => dto.Telefono))
            .ForMember(ent => ent.Direccion, opt => opt.MapFrom(dto => dto.Direccion));

        // Mapeo inverso de PacienteDto a Paciente
        CreateMap<PacienteDto, Paciente>()
            .ForMember(ent => ent.Id, opt => opt.Ignore()) // Ignoramos el Id al actualizar.
            .ForMember(ent => ent.NSS, opt => opt.MapFrom(dto => dto.NSS))
            .ForMember(ent => ent.NumTarjeta, opt => opt.MapFrom(dto => dto.NumTarjeta))
            .ForMember(ent => ent.Telefono, opt => opt.MapFrom(dto => dto.Telefono))
            .ForMember(ent => ent.Direccion, opt => opt.MapFrom(dto => dto.Direccion));

        // Mapeo de EditarPacienteDto a Paciente
        CreateMap<EditarPacienteDto, Paciente>()
            .ForMember(ent => ent.NSS, opt => opt.MapFrom(dto => dto.NSS))
            .ForMember(ent => ent.NumTarjeta, opt => opt.MapFrom(dto => dto.NumTarjeta))
            .ForMember(ent => ent.Telefono, opt => opt.MapFrom(dto => dto.Telefono))
            .ForMember(ent => ent.Direccion, opt => opt.MapFrom(dto => dto.Direccion));
    }
}
