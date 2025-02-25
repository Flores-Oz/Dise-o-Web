using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class AlumUsua
{
    public int IdUsuAlu { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string Carne { get; set; }

    public int IdUsuario { get; set; }

    public virtual Alumno CarneNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }
}
