using Food4You.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model.Requests
{
    public class NarudzbaSearchObject : BaseSearchObject
    {
        public int Id { get; set; }
        public DateTime? DatumNarudzbe { get; set; }
        public int StatusNarudzbeId { get; set; }
        public int KorisnikId { get; set; }
    }
}
