using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public string NombreMunicipio { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual Departamento IdDepartamentoNavigation { get; set; }
}
