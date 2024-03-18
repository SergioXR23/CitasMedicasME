namespace CitasMedicasME.Models.DTOs
{
    // Usado para mostrar información de citas existentes
    public class CitaDto
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }
        public int PacienteId { get; set; } 
        public int MedicoId { get; set; }
    }

    public class CrearCitaDto
    {
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }
        public int PacienteId { get; set; } 
        public int MedicoId { get; set; } 
    }

    public class EditarCitaDto
    {
        public DateTime FechaHora { get; set; }
        public string MotivoCita { get; set; }
    }
}
