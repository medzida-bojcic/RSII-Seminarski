﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model
{
    public partial class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string ImePrezime { get; set; }
        public string KorisnickoIme { get; set; }
        public int DrzavaId { get; set; }
        public int GradId { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public virtual ICollection<KorisniciUloge> KorisnikUlogas { get; } = new List<KorisniciUloge>();

    }
}
