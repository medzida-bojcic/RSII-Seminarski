﻿using System;
using System.Collections.Generic;

namespace Food4You.Services.Database;

public partial class Grad
{
    public int Id { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Korisnik> Korisniks { get; set; } = new List<Korisnik>();
}
