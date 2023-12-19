using System;
using System.Collections.Generic;

namespace IcaAffären.Models;

public partial class PersonalAvdelningar
{
    public int FkAvdelningId { get; set; }

    public int FkPersonalId { get; set; }

    public virtual Avdelning FkAvdelning { get; set; } = null!;

    public virtual Personal FkPersonal { get; set; } = null!;
}
