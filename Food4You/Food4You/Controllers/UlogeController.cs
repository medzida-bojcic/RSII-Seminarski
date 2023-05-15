using Food4You.Services;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UlogeController : BaseController<Model.Uloge, Food4You.Model.Requests.UlogeSearchObject>
    {
        public UlogeController(IUlogeService service) : base(service)
        {

        }
    }
}
