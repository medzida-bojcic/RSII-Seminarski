using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model
{
    public class Uplata
    {
        public int Id { get; set; }
        public double Iznos { get; set; }
        public string BrojTransakcije { get; set; }
        public DateTime DatumTransakcije { get; set; }
        public int KorisnikId { get; set; }
    }
}
