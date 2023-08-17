using Food4You.Model;
using Food4You.Model.Requests;
using Food4You.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Food4You.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class KorisnikController : BaseCRUDController<Model.Korisnik, KorisnikSearchRequest, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {
        protected readonly IKorisniciService _service;
        public KorisnikController(IKorisniciService service) : base(service)
        {
            _service = service;
        }


        //      [HttpGet("Authenticate")]
        //[AllowAnonymous]
        //public async Task<Model.Korisnik> Authenticate()
        //{
        //	string authorization = HttpContext.Request.Headers["Authorization"];

        //	string encodedHeader = authorization["Basic ".Length..].Trim();

        //	Encoding encoding = Encoding.GetEncoding("iso-8859-1");
        //	string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedHeader));

        //	int seperatorIndex = usernamePassword.IndexOf(':');

        //	return await _service.Login(usernamePassword.Substring(0, seperatorIndex), usernamePassword[(seperatorIndex + 1)..]);

    }
}
