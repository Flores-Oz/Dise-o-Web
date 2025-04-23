using System;
using System.Collections.Generic;

namespace MVCCORE_CRUD.Data.Models;

public partial class Marca
{
    public int CodigoMarca { get; set; }

    public string NombreMarca { get; set; } = null!;

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}
