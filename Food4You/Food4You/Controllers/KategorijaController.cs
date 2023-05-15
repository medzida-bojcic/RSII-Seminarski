using Food4You.Model.Requests;
using Food4You.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class KategorijaController : BaseCRUDController<Model.Kategorija, KategorijaSearchObject, KategorijaUpsertRequest, KategorijaUpsertRequest>
    {
        public KategorijaController(IKategorijaService service)
            : base(service)
        {

        }
    }
}
