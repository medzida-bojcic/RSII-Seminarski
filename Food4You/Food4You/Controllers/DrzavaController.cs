using Food4You.Services;

namespace Food4You.Controllers
{

    public class DrzavaController : BaseController<Model.Drzava, Model.Requests.DrzavaSearchObject>
    {
        public IDrzavaService _drzavaService { get; set; }
        public DrzavaController(IDrzavaService drzavaService) : base(drzavaService)
        {
            _drzavaService=drzavaService;
        }
    }
}
