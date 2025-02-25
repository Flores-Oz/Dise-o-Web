using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class EncPago
{
    public string IdEncpago { get; set; }

    public int IdInscripcion { get; set; }

    public DateOnly? FechaEncpago { get; set; }

    public decimal? TotalPago { get; set; }

    public string BoletaPago { get; set; }

    public string NoRecibo { get; set; }

    public DateOnly? FechaBoleta { get; set; }

    public string DescripcionPago { get; set; }

    public string Concepto { get; set; }

    public int? TipoPago { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<DetallePago> DetallePagos { get; set; } = new List<DetallePago>();

    public virtual Inscripcion IdInscripcionNavigation { get; set; }
}
