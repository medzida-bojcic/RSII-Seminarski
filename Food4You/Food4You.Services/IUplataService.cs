using Food4You.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public interface IUplataService : ICRUDService<Model.Uplata, UplataSearchObject, UplataUpsertRequest, UplataUpsertRequest>
    {
        List<Model.Uplata> Get(UplataSearchObject search);
        Task<Model.Uplata> InsertAsync(UplataUpsertRequest request);
    }
}
