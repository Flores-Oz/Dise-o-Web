using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class PagosGrado
{
    public int IdPagosGrado { get; set; }

    public decimal ValorInscripcion { get; set; }

    public decimal ValorMensualidad { get; set; }

    public bool EstadoCouta { get; set; }

    public string IdCarrera { get; set; }

    public int? CantidadPagos { get; set; }

    public int? CoutaCompu { get; set; }

    public int? IdJornada { get; set; }

    public virtual Carrera IdCarreraNavigation { get; set; }
}
