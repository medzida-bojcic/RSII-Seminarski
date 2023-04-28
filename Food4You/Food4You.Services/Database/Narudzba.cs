using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class Narudzba
{
    public int Id { get; set; }

    public DateTime? DatumNarudzbe { get; set; }

    public int? StatusNarudzbeId { get; set; }

    public int? KorisnikId { get; set; }

    public virtual Korisnik? Korisnik { get; set; }

    public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; } = new List<NarudzbaStavke>();

    public virtual StatusNarudzbe? StatusNarudzbe { get; set; }
}
