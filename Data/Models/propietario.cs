using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public partial class propietario
{
    public string dpi { get; set; } = null!;

    public string nombre { get; set; } = null!;

    public string apellido { get; set; } = null!;

    public string prefijo_pais { get; set; } = null!;

    public string telefono { get; set; } = null!;

    public string nit { get; set; } = null!;

    public bool? estado { get; set; }

    public ICollection<recibo_encabezado> recibo_encabezados { get; set; } = new List<recibo_encabezado>();

    public ICollection<propiedad> id_propiedads { get; set; } = new List<propiedad>();
}
