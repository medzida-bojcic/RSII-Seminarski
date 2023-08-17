using Food4You.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model.Requests
{
    public class NarudzbaStavkeSearchObject : BaseSearchObject
    {
        public int MeniId { get; set; }
        public int NarudzbaId { get; set; }
        public int KorisnikId { get; set; }
    }
}
