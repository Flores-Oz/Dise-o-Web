using System;
using System.Collections.Generic;

namespace ZeroOne.Data.Models;

public partial class Cliente
{
    public string NitCliente { get; set; } = null!;

    public string NombreCliente { get; set; } = null!;

    public string ApellidoCliente { get; set; } = null!;

    public string DireccionCliente { get; set; } = null!;

    public string TelefonoCliente { get; set; } = null!;

    public DateTime FechanacCliente { get; set; }

    public bool EstadoCliente { get; set; }

    public int? CodigoMunicipio { get; set; }

    public virtual Municipio? CodigoMunicipioNavigation { get; set; }

    public virtual ICollection<EncaCompra> EncaCompras { get; set; } = new List<EncaCompra>();
}
