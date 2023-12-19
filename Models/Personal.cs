using System;
using System.Collections.Generic;

namespace IcaAffären.Models;

public partial class Personal
{
    public int PersonalId { get; set; }

    public string PersonalNamn { get; set; } = null!;

    public string Personnummer { get; set; } = null!;

    public DateOnly AnställningsDatum { get; set; }

    public string PersonalTelefon { get; set; } = null!;

    public int FkButikId { get; set; }

    public string Kön { get; set; } = null!;

    public virtual Butik FkButik { get; set; } = null!;
}
