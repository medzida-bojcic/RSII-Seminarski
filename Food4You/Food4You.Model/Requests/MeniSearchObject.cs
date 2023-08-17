    using Food4You.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model.Requests
{
    public class MeniSearchObject : BaseSearchObject
    {
        public int KategorijaId { get; set; }
        public string Naziv { get; set; }
    }
}
