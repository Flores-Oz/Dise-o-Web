using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string NombreDepartamento { get; set; }

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
