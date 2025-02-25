using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Notum
{
    public string IdNota { get; set; }

    public int? Notafinal { get; set; }

    public int? IdUnidad { get; set; }

    public int? IdCursoProf { get; set; }

    public int? Zona { get; set; }

    public string Argumento { get; set; }

    public int? Total { get; set; }

    public string IdAlumCurso { get; set; }

    public string Literal { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string TipoNota { get; set; }

    public virtual AsignaCursosalum IdAlumCursoNavigation { get; set; }

    public virtual Unidad IdUnidadNavigation { get; set; }
}
