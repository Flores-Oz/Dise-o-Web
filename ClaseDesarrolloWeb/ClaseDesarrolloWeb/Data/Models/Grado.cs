using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Grado
{
    public int IdGrado { get; set; }

    public string NomGrado { get; set; }

    public bool EstadoGrado { get; set; }

    public virtual ICollection<Pensum> Pensums { get; set; } = new List<Pensum>();
}
