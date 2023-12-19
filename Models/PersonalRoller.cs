using System;
using System.Collections.Generic;

namespace IcaAffären.Models;

public partial class PersonalRoller
{
    public int FkPersonalId { get; set; }

    public int FkRollId { get; set; }

    public virtual Personal FkPersonal { get; set; } = null!;

    public virtual Roll FkRoll { get; set; } = null!;
}
