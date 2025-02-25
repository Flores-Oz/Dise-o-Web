using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Unidad
{
    public int IdUnidad { get; set; }

    public string NombreUnidad { get; set; }

    public DateTime? FechaInicial { get; set; }

    public DateTime? FechaFinal { get; set; }

    public bool? EstadoUnidad { get; set; }

    public virtual ICollection<Notum> Nota { get; set; } = new List<Notum>();
}
