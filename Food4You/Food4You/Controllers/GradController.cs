using Food4You.Model.Requests;
using Food4You.Services;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradController : BaseController<Model.Grad, GradSearchObject>
    {
        public IGradService _gradService { get; set; }
        public GradController(IGradService gradService) : base(gradService)
        {
            _gradService = gradService;
        }
    }
}
