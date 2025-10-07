using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public class Propiedad
{
    public string Id { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Avatar { get; set; }

    public string IdCondominio { get; set; } = null!;

    public Condominio IdCondominioNavigation { get; set; } = null!;

    public ICollection<ReciboEncabezado> ReciboEncabezados { get; set; } =
        new List<ReciboEncabezado>();

    public ICollection<Propietario> DpiPropietarios { get; set; } = new List<Propietario>();
}
