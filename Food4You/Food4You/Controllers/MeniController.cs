using Food4You.Model.Requests;
using Food4You.Services;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeniController  : BaseCRUDController<Model.Meni, MeniSearchObject, MeniUpsertRequest, MeniUpsertRequest>
    {
        public IMeniService service { get; set; }

        public MeniController(IMeniService _service) : base(_service)
        {
            service = _service;
        }

        [HttpGet("preporuceno/{korisnikId}")]

        public List<Model.Meni> GetRecommendedMeni(int korisnikId)
        {
            return service.GetRecommendedMeni(korisnikId);
        }
    }
}
