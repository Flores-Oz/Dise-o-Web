using System;
using System.Collections.Generic;

namespace ParcialOne.Data.Models;

public partial class Alumno
{
    public string CarneAlumno { get; set; } = null!;

    public string Nombre1Alumno { get; set; } = null!;

    public string? Nombre2Alumno { get; set; }

    public string Apellido1Alumno { get; set; } = null!;

    public string? Apellido2Alumno { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public string DireccionAlumno { get; set; } = null!;

    public string TelefonoAlumno { get; set; } = null!;

    public string CorreoAlumno { get; set; } = null!;

    public int CodigoCarrera { get; set; }

    public virtual Carrera CodigoCarreraNavigation { get; set; } = null!;
}
