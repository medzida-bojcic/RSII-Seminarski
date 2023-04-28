using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class KorisnikUloga
{
    public int Id { get; set; }

    public int? KorisnikId { get; set; }

    public int? UlogaId { get; set; }

    public DateTime? DatumIzmjene { get; set; }

    public virtual Korisnik? Korisnik { get; set; }

    public virtual Uloga? Uloga { get; set; }
}
