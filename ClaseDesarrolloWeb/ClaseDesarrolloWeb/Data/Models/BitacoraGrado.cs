using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class BitacoraGrado
{
    public int IdBitacoraGrado { get; set; }

    public int IdGrado { get; set; }

    public string NomGrado { get; set; }

    public bool EstadoGrado { get; set; }

    public DateTime FechaOperacion { get; set; }

    public string Accion { get; set; }
}
