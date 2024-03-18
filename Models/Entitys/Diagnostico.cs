//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//namespace CitasMedicasME.Models.Entitys
//{
//    [Table("Diagnosticos")]
//    public class Diagnostico
//    {
//        [Key, ForeignKey("Cita")]
//        public int Id { get; set; }

//        [Required]
//        [StringLength(255)]
//        public string ValoracionEspecialista { get; set; }

//        [Required]
//        [StringLength(255)]
//        public string Enfermedad { get; set; }

//        // Relación inversa con Cita
//        public virtual Cita Cita { get; set; } 
//    }
//}

using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasME.Models.Entitys
{
    [Table("Diagnosticos")]
    public class Diagnostico
    {
        [Key]
        public int Id { get; set; }  // Clave primaria independiente para Diagnostico

        [Required]
        [StringLength(255)]
        public string ValoracionEspecialista { get; set; }

        [Required]
        [StringLength(255)]
        public string Enfermedad { get; set; }

        // Clave foránea y propiedad de navegación para la relación con Cita
        public int CitaId { get; set; }
        [ForeignKey("CitaId")]
        public virtual Cita Cita { get; set; }  // Propiedad de navegación
    }
}
