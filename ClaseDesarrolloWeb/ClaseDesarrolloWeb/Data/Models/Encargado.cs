using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Encargado
{
    public int IdEncargado { get; set; }

    public string NombreEncargado { get; set; }

    public string ApellidoEncargado { get; set; }

    public string TelCasa { get; set; }

    public string TelCel { get; set; }

    public string DirecEncargado { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
