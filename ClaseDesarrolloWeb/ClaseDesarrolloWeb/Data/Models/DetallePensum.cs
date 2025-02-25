using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class DetallePensum
{
    public int IdDetPen { get; set; }

    public string IdCurso { get; set; }

    public string IdPensum { get; set; }

    public virtual Curso IdCursoNavigation { get; set; }

    public virtual Pensum IdPensumNavigation { get; set; }
}
