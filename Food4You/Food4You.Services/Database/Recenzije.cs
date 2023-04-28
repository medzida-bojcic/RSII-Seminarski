using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class Recenzije
{
    public int Id { get; set; }

    public int? Ocjena { get; set; }

    public string? Opis { get; set; }

    public int? MeniId { get; set; }

    public int? KorisnikId { get; set; }

    public virtual Korisnik? Korisnik { get; set; }

    public virtual Meni? Meni { get; set; }
}
