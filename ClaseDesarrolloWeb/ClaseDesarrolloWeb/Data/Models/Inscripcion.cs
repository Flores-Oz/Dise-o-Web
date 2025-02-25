using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class Inscripcion
{
    public int IdInscripcion { get; set; }

    public string Carne { get; set; }

    public DateOnly FechaInicial { get; set; }

    public DateOnly FechaFinal { get; set; }

    public bool EstadoIns { get; set; }

    public string IdPensum { get; set; }

    public int IdJornada { get; set; }

    public int IdCiclo { get; set; }

    public decimal? CantidadIns { get; set; }

    public decimal? CantidadMensual { get; set; }

    public int? IdRubroIns { get; set; }

    public int? IdRubroMen { get; set; }

    public int? ContadorMes { get; set; }

    public decimal? TotalPagar { get; set; }

    public DateTime? FechaInscripcion { get; set; }

    public int? IdSeccion { get; set; }

    public int? IdUsuario { get; set; }

    public virtual ICollection<AsignaCursosalum> AsignaCursosalums { get; set; } = new List<AsignaCursosalum>();

    public virtual Alumno CarneNavigation { get; set; }

    public virtual ICollection<EncPago> EncPagos { get; set; } = new List<EncPago>();

    public virtual Ciclo IdCicloNavigation { get; set; }

    public virtual Jornadum IdJornadaNavigation { get; set; }

    public virtual Pensum IdPensumNavigation { get; set; }

    public virtual Seccion IdSeccionNavigation { get; set; }
}
