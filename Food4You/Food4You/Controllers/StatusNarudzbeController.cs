using Food4You.Model.Requests;
using Food4You.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class StatusNarudzbeController : BaseController<Model.StatusNarudzbe, StatusNarudzbeSearchObject> 
    {
        protected readonly IStatusNarudzbeService service;
        public StatusNarudzbeController(IStatusNarudzbeService _service) : base(_service)
        {
            service = _service;
        }
    }
}
