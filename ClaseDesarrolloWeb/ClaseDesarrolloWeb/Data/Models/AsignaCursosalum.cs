using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class AsignaCursosalum
{
    public string IdAlumCurso { get; set; }

    public int IdInscripcion { get; set; }

    public string IdCurso { get; set; }

    public int? SumaTotal { get; set; }

    public double? Promedio { get; set; }

    public string Resultado { get; set; }

    public virtual Curso IdCursoNavigation { get; set; }

    public virtual Inscripcion IdInscripcionNavigation { get; set; }

    public virtual ICollection<Notum> Nota { get; set; } = new List<Notum>();
}
