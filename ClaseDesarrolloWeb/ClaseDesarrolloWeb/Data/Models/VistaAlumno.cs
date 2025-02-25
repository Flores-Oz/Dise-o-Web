using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class VistaAlumno
{
    public string Carne { get; set; }

    public string Apellido1 { get; set; }

    public string Apellido2 { get; set; }

    public string Nombre1 { get; set; }

    public string Nombre2 { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string Sexo { get; set; }

    public int? Estado { get; set; }

    public string Direccion { get; set; }

    public string Telefono { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string Municipio { get; set; }

    public string Departamento { get; set; }
}
