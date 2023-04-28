using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class NarudzbaStavke
{
    public int Id { get; set; }

    public int? Kolicina { get; set; }

    public decimal? Cijena { get; set; }

    public int? MeniId { get; set; }

    public int? NarudzbaId { get; set; }

    public virtual Meni? Meni { get; set; }

    public virtual Narudzba? Narudzba { get; set; }
}
