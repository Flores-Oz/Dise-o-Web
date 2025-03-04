using System;
using System.Collections.Generic;

namespace ZeroOne.Data.Models;

public partial class DetalleVentum
{
    public int CodigoDetalleVenta { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioCosto { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal Subtotal { get; set; }

    public int CodigoProducto { get; set; }

    public int CodigoVenta { get; set; }

    public virtual Producto CodigoProductoNavigation { get; set; } = null!;

    public virtual EncaVentum CodigoVentaNavigation { get; set; } = null!;
}
