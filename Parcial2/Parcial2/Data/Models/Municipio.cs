using System;
using System.Collections.Generic;

namespace Parcial2.Data.Models;

public partial class Municipio
{
    public int CodigoMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public int CodigoDepartamento { get; set; }

    public virtual Departamento CodigoDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
