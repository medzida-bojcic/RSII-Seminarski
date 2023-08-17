using Food4You.Model;
using Food4You.Model.Requests;
using Food4You.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class NarudzbeController : BaseCRUDController<Model.Narudzba, NarudzbaSearchObject, NarudzbaUpsertRequest, NarudzbaUpsertRequest>
    {
        private readonly INarudzbaService _service;
     
        public NarudzbeController(INarudzbaService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("{id}/allowedActions")]
        public virtual async Task<List<string>> AllowedActions(int id)
        {
            return await _service.AllowedActions(id);
        }

        [HttpPut("{id}/accept")]
        public virtual async Task<Narudzba> Accept(int id)
        {
            return await _service.Accept(id);
        }

        [HttpPut("{id}/inProgress")]
        public virtual async Task<Narudzba> inProgress(int id)
        {
            return await _service.InProgress(id);
        }

        [HttpPut("{id}/finish")]
        public virtual async Task<Narudzba> Finish(int id)
        {
            return await _service.Finish(id);
        }

        [HttpPut("{id}/deliver")]
        public virtual async Task<Narudzba> Deliver(int id)
        {
            return await _service.Deliver(id);
        }

        [HttpPut("{id}/cancel")]
        public virtual async Task<Narudzba> Cancel(int id)
        {
            return await _service.Cancel(id);
        }
    }
}
