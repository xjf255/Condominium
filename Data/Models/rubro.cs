using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public partial class rubro
{
    public int id { get; set; }

    public string nombre { get; set; } = null!;

    public decimal cuota { get; set; }

    public ICollection<recibo_detalle> recibo_detalles { get; set; } = new List<recibo_detalle>();
}
