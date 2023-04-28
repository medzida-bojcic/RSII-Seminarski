using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class Meni
{
    public int Id { get; set; }

    public string? Naziv { get; set; }

    public string? Slika { get; set; }

    public string? Opis { get; set; }

    public decimal? Cijena { get; set; }

    public int? KategorijaId { get; set; }

    public virtual Kategorija? Kategorija { get; set; }

    public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; } = new List<NarudzbaStavke>();

    public virtual ICollection<Recenzije> Recenzijes { get; set; } = new List<Recenzije>();
}
