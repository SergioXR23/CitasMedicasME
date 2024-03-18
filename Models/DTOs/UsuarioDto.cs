using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CitasMedicasME.Models.DTOs
{
    public class UsuarioDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)] //Nos aseguramos que los datos que se ingresen sean de un tamaño específico y obligatorios 
        public string Username { get; set; }

        //Aquí supongamos que no queremos que se muestre la contraseña en el DTO por ejemplo y no la colocamos aquí
        public string Clave { get; set; }
    }

    public class CrearUsuarioDto
    {
        [JsonIgnore]
        public int Id { get; set; }
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
        public string Clave { get; set; }
    }

    public class loginDto
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Clave { get; set; }

    }

}
