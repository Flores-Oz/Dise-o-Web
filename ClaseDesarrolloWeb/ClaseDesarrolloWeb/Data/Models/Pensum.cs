using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Pensum
{
    public string IdPensum { get; set; }

    public string NomPensum { get; set; }

    public int IdGrado { get; set; }

    public DateTime FechaInicio { get; set; }

    public bool EstadoPensum { get; set; }

    public string IdCarrera { get; set; }

    public virtual ICollection<DetallePensum> DetallePensums { get; set; } = new List<DetallePensum>();

    public virtual Carrera IdCarreraNavigation { get; set; }

    public virtual Grado IdGradoNavigation { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
