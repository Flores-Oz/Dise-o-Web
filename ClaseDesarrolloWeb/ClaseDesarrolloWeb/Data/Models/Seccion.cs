using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Seccion
{
    public int IdSeccion { get; set; }

    public string NombreSeccion { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
