using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Model.Requests
{
    public class RecenzijaUpsertRequest
    {
        public int Id { get; set; }

        [Range(1,5)]
        public int Ocjena { get; set; }
        public string Opis { get; set; }
        public int MeniId { get; set; }
        public int KorisnikId { get; set; }
    }
}
