using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public partial class condominio
{
    public string id { get; set; } = null!;

    public string nombre { get; set; } = null!;

    public string direccion { get; set; } = null!;

    public string? image_condominio { get; set; }

    public ICollection<propiedad> propiedads { get; set; } = new List<propiedad>();
}
