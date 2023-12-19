using System;
using System.Collections.Generic;

namespace IcaAffären.Models;

public partial class ButiksAvdelningar
{
    public int FkButikId { get; set; }

    public int FkAvdelningId { get; set; }

    public virtual Avdelning FkButik { get; set; } = null!;

    public virtual Butik FkButikNavigation { get; set; } = null!;
}
