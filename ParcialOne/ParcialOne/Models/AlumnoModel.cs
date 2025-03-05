namespace ParcialOne.Models
{
    public class AlumnoModel
    {
        public string? CarneAlumno { get; set; }

        public string? Nombre1Alumno { get; set; }

        public string? Nombre2Alumno { get; set; }

        public string? Apellido1Alumno { get; set; }

        public string? Apellido2Alumno { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string? DireccionAlumno { get; set; }

        public string? TelefonoAlumno { get; set; }
        public string? CorreoAlumno { get; set; }

        public int CodigoCarrera { get; set; }
        public string? Carrera { get; set; }
    }
}
