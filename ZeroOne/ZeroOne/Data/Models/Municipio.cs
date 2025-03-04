using System;
using System.Collections.Generic;

namespace ZeroOne.Data.Models;

public partial class Municipio
{
    public int CodigoMunicipio { get; set; }

    public string NombreMunicipio { get; set; } = null!;

    public int CodigoDepartamento { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Departamento CodigoDepartamentoNavigation { get; set; } = null!;
}
