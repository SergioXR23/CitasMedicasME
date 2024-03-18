using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasMedicasME.Models.Entitys
{
 
        // La clase Paciente hereda de Usuario
        [Table("Pacientes")] // Esta anotación es para la estrategia TPT
        public class Paciente : Usuario // Indica la herencia
        {
            [Required]
            [StringLength(20)]
            public string NSS { get; set; }  

            [Required]
            [StringLength(20)]
            public string NumTarjeta { get; set; } 

            [Required]
            [StringLength(15)]
            public string Telefono { get; set; }

            [Required]
            [StringLength(255)]
            public string Direccion { get; set; }

            // Relación con Cita
            public List<Cita> Citas { get; set; }
    }

    }

