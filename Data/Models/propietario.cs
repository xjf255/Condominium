using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public class Propietario
{
    public string Dpi { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string PrefijoPais { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Nit { get; set; } = null!;

    public bool? Estado { get; set; }

    public ICollection<ReciboEncabezado> ReciboEncabezados { get; set; } = new List<ReciboEncabezado>();

    public ICollection<Propiedad> IdPropiedades { get; set; } = new List<Propiedad>();
}
