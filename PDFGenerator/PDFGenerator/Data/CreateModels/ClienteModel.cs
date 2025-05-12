using System;
using System.Collections.Generic;

namespace PDFGenerator.Models;

public partial class ClienteModel
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public int? MunicipioId { get; set; }

    public string Municipio { get; set; } = null!;

    public int? CodigoDepartamento { get; set; }

    public string Departamento { get; set; } = null!;
}
