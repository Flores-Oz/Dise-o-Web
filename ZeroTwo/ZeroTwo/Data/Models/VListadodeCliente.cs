using System;
using System.Collections.Generic;

namespace ZeroTwo.Data.Models;

public partial class VListadodeCliente
{
    public string Nit { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public DateTime FechaNac { get; set; }
}
