using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class Kategorija
{
    public int Id { get; set; }

    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public virtual ICollection<Meni> Menis { get; set; } = new List<Meni>();
}
