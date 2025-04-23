namespace Parcial2.Data.CreateModels
{
    public class PacienteModel
    {
        public int CodigoPaciente { get; set; }

        public string DpiPaciente { get; set; } = null!;

        public string NombrePaciente { get; set; } = null!;

        public string ApellidoPaciente { get; set; } = null!;

        public DateTime FechaNac { get; set; }

        public bool EstadoPaciente { get; set; }

        public int CodigoMunicipio { get; set; }

        public string Municipio { get; set; } = null!;
        public int? CodigoDepartamento { get; set; }
        public string Departamento { get; set; } = null!;
    }
}
