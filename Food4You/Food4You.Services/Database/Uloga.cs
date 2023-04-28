using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class Uloga
{
    public int Id { get; set; }

    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public virtual ICollection<KorisnikUloga> KorisnikUlogas { get; set; } = new List<KorisnikUloga>();
}
