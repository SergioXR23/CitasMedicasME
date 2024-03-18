namespace CitasMedicasME.Models.DTOs
{
    public class DiagnosticoDto
    {
        public int Id { get; set; }
        public string ValoracionEspecialista { get; set; }
        public string Enfermedad { get; set; }
        public int CitaId { get; set; }
    }

    namespace CitasMedicasME.Models.DTOs
    {
        public class CrearDiagnosticoDto
        {
            public string ValoracionEspecialista { get; set; }
            public string Enfermedad { get; set; }
        }
    }
    namespace CitasMedicasME.Models.DTOs
    {
        public class EditarDiagnosticoDto
        {
            public string ValoracionEspecialista { get; set; }
            public string Enfermedad { get; set; }
            // No es necesario incluir el Id si se pasa a través de la ruta de la URL en la API
        }
    }



}