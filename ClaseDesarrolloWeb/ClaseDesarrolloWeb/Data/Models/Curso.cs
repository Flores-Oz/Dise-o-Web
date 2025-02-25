using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Curso
{
    public string IdCurso { get; set; }

    public string NomCurso { get; set; }

    public bool EstadoCurso { get; set; }

    public virtual ICollection<AsignaCursosalum> AsignaCursosalums { get; set; } = new List<AsignaCursosalum>();

    public virtual ICollection<DetallePensum> DetallePensums { get; set; } = new List<DetallePensum>();
}
