using Food4You.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        public IBaseService<T, TSearch> _service { get; set; }

        public BaseController(IBaseService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery] TSearch search = null)
        {
            return _service.Get(search);
        }
        [HttpGet("{id}")]
        public virtual T GetbyId(int id)
        {
            return _service.GetById(id);
        }
    }

}
