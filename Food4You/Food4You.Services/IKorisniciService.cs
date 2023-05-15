using Food4You.Model;
using Food4You.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public interface IKorisniciService : ICRUDService<Model.Korisnik, KorisnikSearchRequest, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {
        IList<Model.Korisnik> GetAll();
        IList<Model.Korisnik> Get(KorisnikSearchRequest search);
        Task<Model.Korisnik> Insert(KorisnikUpsertRequest korisnici);

        Task<Model.Korisnik> Login(string korisnickoIme, string lozinka);

    }
}
