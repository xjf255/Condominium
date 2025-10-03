using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public partial class recibo_encabezado
{
    public string num_rec { get; set; } = null!;

    public DateTime? fecha_recibo { get; set; }

    public string id_propiedad { get; set; } = null!;

    public string dpi_propietario { get; set; } = null!;

    public propietario dpi_propietarioNavigation { get; set; } = null!;

    public propiedad id_propiedadNavigation { get; set; } = null!;

    public ICollection<recibo_detalle> recibo_detalles { get; set; } = new List<recibo_detalle>();
}
