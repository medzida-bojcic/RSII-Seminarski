using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model.Requests
{
    public class NarudzbaStavkeUpsertRequest
    {
        public int Kolicina { get; set; }

        [Range(0, double.MaxValue)]
        public int Cijena { get; set; }
        public int MeniId { get; set; }
        //public Meni Meni { get; set; }
        public int NarudzbaId { get; set; }
    }
}
