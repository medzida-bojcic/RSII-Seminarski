using Food4You.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model.Requests
{
    public class RecenzijaSearchObject : BaseSearchObject
    {
        public int Id { get; set; }
        public int Ocjena { get; set; }
        public string Opis { get; set; }
        public int MeniId { get; set; }
        public int KorisnikId { get; set; }
    }
}
