using Food4You.Model.Requests;
using Food4You.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class StavkeNarudzbeController : BaseCRUDController<Model.NarudzbaStavke, NarudzbaStavkeSearchObject, NarudzbaStavkeUpsertRequest, NarudzbaStavkeUpsertRequest>
    {
        protected readonly IStavkeNarudzbeService service;
        public StavkeNarudzbeController(IStavkeNarudzbeService _service) : base(_service)
        {
            service=_service;
        }
    }
}
