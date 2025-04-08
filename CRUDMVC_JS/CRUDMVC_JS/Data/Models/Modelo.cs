using System;
using System.Collections.Generic;

namespace CRUDMVC_JS.Data.Models;

public partial class Modelo
{
    public int CodigoModelo { get; set; }

    public string? NombreModelo { get; set; }

    public int? CodigoMarca { get; set; }

    public virtual Marca? CodigoMarcaNavigation { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
