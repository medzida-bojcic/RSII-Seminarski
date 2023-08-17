using Food4You.Model.Requests;
using Food4You.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class UplataController : BaseCRUDController<Model.Uplata, UplataSearchObject, UplataUpsertRequest, UplataUpsertRequest>
    {
        protected readonly IUplataService _service;
        public UplataController(IUplataService service) : base(service)
        {
            _service = service;
        }
    }
}
