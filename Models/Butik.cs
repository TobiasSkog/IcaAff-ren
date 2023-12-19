using System;
using System.Collections.Generic;

namespace IcaAffären.Models;

public partial class Butik
{
    public int ButikId { get; set; }

    public string ButikNamn { get; set; } = null!;

    public string ButikAdress { get; set; } = null!;

    public string ButikTelefon { get; set; } = null!;

    public virtual ICollection<Personal> Personals { get; set; } = new List<Personal>();
}
