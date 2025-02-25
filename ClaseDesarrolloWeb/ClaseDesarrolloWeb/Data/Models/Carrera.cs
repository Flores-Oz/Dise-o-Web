using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Carrera
{
    public string IdCarrera { get; set; }

    public string NombreCarrera { get; set; }

    public bool EstadoCarrera { get; set; }

    public virtual ICollection<PagosGrado> PagosGrados { get; set; } = new List<PagosGrado>();

    public virtual ICollection<Pensum> Pensums { get; set; } = new List<Pensum>();
}
