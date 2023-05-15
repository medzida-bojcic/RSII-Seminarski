using Food4You.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model.Requests
{
    public class KorisnikSearchRequest : BaseSearchObject
    {
        public string ImePrezime { get; set; }
    }
}
