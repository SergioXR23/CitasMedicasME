using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasME.Models.Entitys
{
    [Table("Citas")]
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        [StringLength(255)]
        public string MotivoCita { get; set; }

        // Clave foránea y propiedad de navegación para la relación con Paciente
        public int PacienteId { get; set; }
        [ForeignKey("PacienteId")]
        public virtual Paciente Paciente { get; set; }

        // Clave foránea y propiedad de navegación para la relación con Medico
        public int MedicoId { get; set; }
        [ForeignKey("MedicoId")]
        public virtual Medico Medico { get; set; } //virtual para lazy loading (carga diferida) 

        // Relación uno a uno con Diagnostico
        // En este caso, DiagnosticoId es tanto una FK como la PK de Diagnostico,
        // lo que refleja una relación de llave principal compartida.
        [ForeignKey("Id")]
        public virtual Diagnostico Diagnostico { get; set; }
    }
}
