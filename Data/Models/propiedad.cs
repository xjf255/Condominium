using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public partial class propiedad
{
    public string id { get; set; } = null!;

    public string direccion { get; set; } = null!;

    public string? avatar { get; set; }

    public string id_condominio { get; set; } = null!;

    public condominio id_condominioNavigation { get; set; } = null!;

    public ICollection<recibo_encabezado> recibo_encabezados { get; set; } =
        new List<recibo_encabezado>();

    public ICollection<propietario> dpi_propietarios { get; set; } = new List<propietario>();
}
