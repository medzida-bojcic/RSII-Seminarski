﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model.Requests
{
    public class KategorijaUpsertRequest
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
