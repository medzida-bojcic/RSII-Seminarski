using Food4You.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public interface IMeniService : ICRUDService<Model.Meni, MeniSearchObject, MeniUpsertRequest, MeniUpsertRequest>
    {
        List<Model.Meni> GetRecommendedMeni(int korisnikId);
    }
}
