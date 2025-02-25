using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; }

    public int IdTipousu { get; set; }

    public bool Estadousu { get; set; }

    public string Contrasenia { get; set; }

    public string NomModServ { get; set; }

    public virtual ICollection<AlumUsua> AlumUsuas { get; set; } = new List<AlumUsua>();
}
