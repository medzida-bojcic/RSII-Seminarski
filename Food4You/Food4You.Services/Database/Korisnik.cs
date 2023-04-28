using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class Korisnik
{
    public int Id { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public int? GradId { get; set; }

    public int? DrzavaId { get; set; }

    public string? KorisnickoIme { get; set; }

    public string? LozinkaHash { get; set; }

    public string? LozinkaSalt { get; set; }

    public virtual Drzava? Drzava { get; set; }

    public virtual Grad? Grad { get; set; }

    public virtual ICollection<KorisnikUloga> KorisnikUlogas { get; set; } = new List<KorisnikUloga>();

    public virtual ICollection<Narudzba> Narudzbas { get; set; } = new List<Narudzba>();

    public virtual ICollection<Recenzije> Recenzijes { get; set; } = new List<Recenzije>();

    public virtual ICollection<Uplatum> Uplata { get; set; } = new List<Uplatum>();
}
