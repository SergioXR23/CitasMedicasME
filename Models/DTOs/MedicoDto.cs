namespace CitasMedicasME.Models.DTOs
{
    public class MedicoDto : UsuarioDto
    {
        public int Id { get; set; }
        public string NumColegiado { get; set; }
    }


    public class CrearMedicoDto : CrearUsuarioDto
    {
        public string NumColegiado { get; set; }
    }

    public class EditarMedicoDto
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Username { get; set; }
        public string Clave { get; set; }
        public string NumColegiado { get; set; }
    }

}
