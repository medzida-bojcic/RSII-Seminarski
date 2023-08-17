using Food4You.Model.Requests;
using Food4You.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class RecenzijeController : BaseCRUDController<Model.Recenzije, RecenzijaSearchObject, RecenzijaUpsertRequest, RecenzijaUpsertRequest>
    {
        protected readonly IRecenzijeService service;
        public RecenzijeController(IRecenzijeService _service) : base(_service)
        {
             service= _service; 
        }
    }
}
