using System;
using System.Collections.Generic;

namespace PDFGenerator.Data.Models;

public partial class Municipio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? DepartamentoId { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Departamento? Departamento { get; set; }
}
