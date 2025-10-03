using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public partial class recibo_detalle
{
    public string num_rec { get; set; } = null!;

    public int id_rubro { get; set; }

    public decimal cuota { get; set; }

    public rubro id_rubroNavigation { get; set; } = null!;

    public recibo_encabezado num_recNavigation { get; set; } = null!;
}
