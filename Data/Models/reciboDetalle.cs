using System;
using System.Collections.Generic;

namespace Condominium.Data.Models;

public partial class ReciboDetalle
{
    public string NumRec { get; set; } = null!;

    public int IdRubro { get; set; }

    public decimal Cuota { get; set; }

    public Rubro IdRubroNavigation { get; set; } = null!;

    public ReciboEncabezado NumRecNavigation { get; set; } = null!;
}
