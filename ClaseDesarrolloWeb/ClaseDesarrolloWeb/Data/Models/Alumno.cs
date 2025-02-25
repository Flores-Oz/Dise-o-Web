using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Alumno
{
    public string Carne { get; set; }

    public string Apellido1Alumno { get; set; }

    public string Apellido2Alumno { get; set; }

    public string Nombre1Alumno { get; set; }

    public string Nombre2Alumno { get; set; }

    public DateTime? Fechanac { get; set; }

    public string SexoAlumno { get; set; }

    public int? EstadoAlumno { get; set; }

    public string DireccionAlumno { get; set; }

    public string CelularAlumno { get; set; }

    public DateTime? Fechaingreso { get; set; }

    public int? IdMuni { get; set; }

    public int? NumeroActualizacion { get; set; }

    public int? IdEncargado { get; set; }

    public virtual ICollection<AlumUsua> AlumUsuas { get; set; } = new List<AlumUsua>();

    public virtual Encargado IdEncargadoNavigation { get; set; }

    public virtual Municipio IdMuniNavigation { get; set; }

    public virtual ICollection<Inscripcion> Inscripcions { get; set; } = new List<Inscripcion>();
}
