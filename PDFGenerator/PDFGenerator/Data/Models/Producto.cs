using System;
using System.Collections.Generic;

namespace PDFGenerator.Data.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public virtual ICollection<Detallefactura> Detallefacturas { get; set; } = new List<Detallefactura>();
}
