﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model
{
    public class Narudzba
    {
        public int Id { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public int StatusNarudzbeId { get; set; }
        public string StatusNarudzbe { get; set; }
        public string? StateMachine { get; set; }
        public int KorisnikId { get; set; }
        public string Korisnik { get; set; }
    }
}
