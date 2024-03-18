using System.ComponentModel.DataAnnotations;

namespace CitasMedicasME.Models.Entitys
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } // Username aquí para evitar la confusión con el nombre de la clase.

        [Required]
        [StringLength(255)]
        public string Clave { get; set; }
    }
}
