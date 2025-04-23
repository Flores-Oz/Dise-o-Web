using System;
using System.Collections.Generic;

namespace MVCCORE_CRUD.Data.Models;

public partial class Producto
{
    public int CodigoProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public decimal PrecioCosto { get; set; }

    public decimal PrecioVenta { get; set; }

    public int ExistenciaProducto { get; set; }

    public int CodigoModelo { get; set; }

    public virtual Modelo CodigoModeloNavigation { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVentum> DetalleVenta { get; set; } = new List<DetalleVentum>();
}
