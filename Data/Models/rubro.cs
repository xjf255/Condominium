using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public partial class Rubro
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Cuota { get; set; }

    public ICollection<ReciboDetalle> ReciboDetalles { get; set; } = new List<ReciboDetalle>();
}
