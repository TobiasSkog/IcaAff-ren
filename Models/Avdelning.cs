using System;
using System.Collections.Generic;

namespace IcaAffären.Models;

public partial class Avdelning
{
    public int AvdelningsId { get; set; }

    public string AvdelningsNamn { get; set; } = null!;
}
