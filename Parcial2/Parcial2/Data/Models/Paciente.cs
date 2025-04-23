using System;
using System.Collections.Generic;

namespace Parcial2.Data.Models;

public partial class Paciente
{
    public int CodigoPaciente { get; set; }

    public string DpiPaciente { get; set; } = null!;

    public string NombrePaciente { get; set; } = null!;

    public string ApellidoPaciente { get; set; } = null!;

    public DateTime FechaNac { get; set; }

    public bool EstadoPaciente { get; set; }

    public int CodigoMunicipio { get; set; }

    public virtual Municipio CodigoMunicipioNavigation { get; set; } = null!;
}
