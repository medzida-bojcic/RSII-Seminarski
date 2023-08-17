using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model
{
    public class NarudzbaStavke
    {
        public int Id { get; set; }
        public int? Kolicina { get; set; }
        public decimal? Cijena { get; set; }
        public int? MeniId { get; set; }
        public int? NarudzbaId { get; set; }
        public decimal? Ukupno { get { return Cijena * Kolicina; } }
    }
}
