using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CitasMedicasME.Models.Entitys
{
  
        [Table("Medicos")] // Esto es para herencia TPT (Table Per Type) 
        public class Medico : Usuario
        {
            [Required]
            [StringLength(50)]
            public string NumColegiado { get; set; }

            // Relación con Cita]
            [Required]
            [StringLength(50)]
            public List<Cita> Citas { get; set; }
    }
    
}
