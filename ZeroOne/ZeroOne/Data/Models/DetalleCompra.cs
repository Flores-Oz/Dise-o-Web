using System;
using System.Collections.Generic;

namespace ZeroOne.Data.Models;

public partial class DetalleCompra
{
    public int CodigoDetalleCompra { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioCosto { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal Subtotal { get; set; }

    public int CodigoCompra { get; set; }

    public int CodigoProducto { get; set; }

    public virtual EncaCompra CodigoCompraNavigation { get; set; } = null!;

    public virtual Producto CodigoProductoNavigation { get; set; } = null!;
}
