using System;
using System.Collections.Generic;

namespace ZeroOne.Data.Models;

public partial class Proveedor
{
    public string NitProveedor { get; set; } = null!;

    public string NombreProveedor { get; set; } = null!;

    public string DireccionProveedor { get; set; } = null!;

    public string TelefonoProveedor { get; set; } = null!;

    public virtual ICollection<EncaVentum> EncaVenta { get; set; } = new List<EncaVentum>();
}
