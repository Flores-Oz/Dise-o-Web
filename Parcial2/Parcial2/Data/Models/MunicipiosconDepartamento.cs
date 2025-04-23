using System;
using System.Collections.Generic;

namespace Parcial2.Data.Models;

public partial class MunicipiosconDepartamento
{
    public int Codigo { get; set; }

    public string Municipio { get; set; } = null!;

    public string Departamento { get; set; } = null!;
}
