using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class DetallePago
{
    public string IdDetPago { get; set; }

    public int IdPago { get; set; }

    public string IdEncpago { get; set; }

    public int NumeroMes { get; set; }

    public int? IdRubro { get; set; }

    public decimal? Valor { get; set; }

    public int? Cantidad { get; set; }

    public decimal? CantidadAbono { get; set; }

    public int? IdInscripcion { get; set; }

    public string IdCurso { get; set; }

    public virtual EncPago IdEncpagoNavigation { get; set; }

    public virtual Pago IdPagoNavigation { get; set; }
}
