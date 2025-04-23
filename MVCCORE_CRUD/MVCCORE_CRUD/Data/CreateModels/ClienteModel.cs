namespace MVCCORE_CRUD.Data.CreateModels
{
    public class ClienteModel
    {
        public string NitCliente { get; set; } = null!;

        public string NombreCliente { get; set; } = null!;

        public string ApellidoCliente { get; set; } = null!;

        public string DireccionCliente { get; set; } = null!;

        public string TelefonoCliente { get; set; } = null!;

        public DateTime FechanacCliente { get; set; }

        public bool EstadoCliente { get; set; }

        public int? CodigoMunicipio { get; set; }
        public string Municipio { get; set; } = null!;

        public int? CodigoDepartamento { get; set; }
        public string Departamento { get; set; } = null!;
    }
}
