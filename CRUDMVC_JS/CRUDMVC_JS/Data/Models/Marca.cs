using System;
using System.Collections.Generic;

namespace CRUDMVC_JS.Data.Models;

public partial class Marca
{
    public int CodigoMarca { get; set; }

    public string NombreMarca { get; set; } = null!;

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}
