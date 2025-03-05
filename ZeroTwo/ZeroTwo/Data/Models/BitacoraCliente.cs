using System;
using System.Collections.Generic;

namespace ZeroTwo.Data.Models;

public partial class BitacoraCliente
{
    public int Id { get; set; }

    public string NitCliente { get; set; } = null!;

    public string NombreCliente { get; set; } = null!;

    public string ApellidoCliente { get; set; } = null!;

    public string DireccionCliente { get; set; } = null!;

    public string TelefonoCliente { get; set; } = null!;

    public DateTime FechanacCliente { get; set; }

    public bool EstadoCliente { get; set; }

    public int CodigoMunicipio { get; set; }

    public string? NombreMunicipio { get; set; }

    public DateTime FechaEvento { get; set; }

    public string TipoEvento { get; set; } = null!;
}
