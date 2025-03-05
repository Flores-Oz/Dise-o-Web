using System;
using System.Collections.Generic;

namespace ZeroTwo.Data.Models;

public partial class Departamento
{
    public int CodigoDepartamento { get; set; }

    public string NombreDepartamento { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
