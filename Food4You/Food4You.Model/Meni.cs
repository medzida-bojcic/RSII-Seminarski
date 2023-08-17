using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model
{
    public class Meni
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Slika { get; set; }
        public decimal Cijena { get; set; }
        public string Opis { get; set; }
        public int KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
