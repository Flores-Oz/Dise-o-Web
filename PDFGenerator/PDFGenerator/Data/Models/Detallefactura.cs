using System;
using System.Collections.Generic;

namespace PDFGenerator.Data.Models;

public partial class Detallefactura
{
    public int Id { get; set; }

    public int? FacturaId { get; set; }

    public int? ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Total { get; set; }

    public virtual Factura? Factura { get; set; }

    public virtual Producto? Producto { get; set; }
}
