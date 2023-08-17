﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model.Requests
{
    public class MeniUpsertRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Cijena { get; set; }
        public string Slika { get; set; }
        public int KategorijaId { get; set; }
    }
}
