using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Ciclo
{
    public int IdCiclo { get; set; }

    public string NombreCiclo { get; set; }

    public bool? EstadoCiclo { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
