using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public partial class ReciboEncabezado
{
    public string NumRec { get; set; } = null!;

    public DateTime? FechaRecibo { get; set; }

    public string IdPropiedad { get; set; } = null!;

    public string DpiPropietario { get; set; } = null!;

    public Propietario DpiPropietarioNavigation { get; set; } = null!;

    public Propiedad IdPropiedadNavigation { get; set; } = null!;

    public ICollection<ReciboDetalle> ReciboDetalles { get; set; } = new List<ReciboDetalle>();
}
