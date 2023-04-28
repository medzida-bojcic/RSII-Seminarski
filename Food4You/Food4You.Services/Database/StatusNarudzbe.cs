using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class StatusNarudzbe
{
    public int Id { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Narudzba> Narudzbas { get; set; } = new List<Narudzba>();
}
