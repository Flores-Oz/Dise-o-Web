using System;
using System.Collections.Generic;

namespace ZeroTwo.Data.Models;

public partial class EncaVentum
{
    public int CodigoVenta { get; set; }

    public DateTime FechaVenta { get; set; }

    public decimal TotalVenta { get; set; }

    public int TotalProductos { get; set; }

    public string NitProveedor { get; set; } = null!;

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();

    public virtual Proveedor NitProveedorNavigation { get; set; } = null!;
}
