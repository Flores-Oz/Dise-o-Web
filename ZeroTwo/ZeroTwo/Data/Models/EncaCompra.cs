using System;
using System.Collections.Generic;

namespace ZeroTwo.Data.Models;

public partial class EncaCompra
{
    public int CodigoCompra { get; set; }

    public DateTime FechaCompra { get; set; }

    public decimal TotalCompra { get; set; }

    public int TotalProducto { get; set; }

    public string DpiCliente { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Cliente DpiClienteNavigation { get; set; } = null!;
}
