using System.ComponentModel.DataAnnotations;

namespace CitasMedicasME.Models.DTOs
{
    public class PacienteDto : UsuarioDto
    {
            public int Id { get; set; }
            public string NSS { get; set; }
            public string NumTarjeta { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }        
    }
    public class CrearPacienteDto : CrearUsuarioDto
    {
            public string NSS { get; set; }
            public string NumTarjeta { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
    }

    public class EditarPacienteDto 
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }


        [Required]
        [StringLength(50)]
        public string NSS { get; set; }

        [Required]
        [StringLength(50)]
        public string NumTarjeta { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(255)]
        public string Direccion { get; set; }

        
    }

}
