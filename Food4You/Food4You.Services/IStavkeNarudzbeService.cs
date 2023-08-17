using Food4You.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public interface IStavkeNarudzbeService : ICRUDService<Model.NarudzbaStavke, NarudzbaStavkeSearchObject, NarudzbaStavkeUpsertRequest, NarudzbaStavkeUpsertRequest>
    {
        Task<List<Model.NarudzbaStavke>> InsertAsync(List<NarudzbaStavkeUpsertRequest> request);
        /*List<Model.NarudzbaStavke> Get(NarudzbaStavkeSearchObject search);*/
    }
}
