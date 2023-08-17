using Food4You.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public interface INarudzbaService : ICRUDService<Model.Narudzba, NarudzbaSearchObject, NarudzbaUpsertRequest, NarudzbaUpsertRequest>
    {
        List<Model.Narudzba> Get(NarudzbaSearchObject search);
        Task<Model.Narudzba> UpdateAsync(int id, NarudzbaUpsertRequest request);
        Task<List<string>> AllowedActions(int id);

        Task<Model.Narudzba> Accept(int id);
        Task<Model.Narudzba> InProgress(int id);
        Task<Model.Narudzba> Finish(int id);
        Task<Model.Narudzba> Deliver(int id);
        Task<Model.Narudzba> Cancel(int id);
    }
}
