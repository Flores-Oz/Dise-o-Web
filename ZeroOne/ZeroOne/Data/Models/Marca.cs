using System;
using System.Collections.Generic;

namespace ZeroOne.Data.Models;

public partial class Marca
{
    public int CodigoMarca { get; set; }

    public string NombreMarca { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
