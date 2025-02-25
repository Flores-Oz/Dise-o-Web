using System;
using System.Collections.Generic;

namespace ClaseDesarrolloWeb.Data.Models;

public partial class BitacoraCarrera
{
    public int IdBitacora { get; set; }

    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; }

    public bool EstadoCarrera { get; set; }

    public DateTime FechaAccion { get; set; }

    public string TipoAccion { get; set; }
}
