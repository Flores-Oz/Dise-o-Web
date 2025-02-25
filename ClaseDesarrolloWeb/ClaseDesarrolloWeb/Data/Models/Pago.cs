using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public string NomPago { get; set; }

    public bool EstadoPago { get; set; }

    public string Valor { get; set; }

    public virtual ICollection<DetallePago> DetallePagos { get; set; } = new List<DetallePago>();
}
