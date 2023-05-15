using AutoMapper;
using Food4You.Model.Requests;
using Food4You.SearchObjects;
using Food4You.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public class KorisniciService : BaseCRUDService<Model.Korisnik, Database.Korisnik, KorisnikSearchRequest, KorisnikUpsertRequest, KorisnikUpsertRequest>, IKorisniciService
    {
        public Food4YouContext Context { get; set; }
        public  IMapper Mapper { get; set; }

        public KorisniciService(Food4YouContext context, IMapper mapper) : base(context, mapper)
        {
            Context=context;
            Mapper=mapper;  
        }

        public override IList<Model.Korisnik> Get(KorisnikSearchRequest search)
        {
            var query = Context.Korisniks.AsQueryable();

            if(!string.IsNullOrWhiteSpace(search?.ImePrezime))
            {
                query = query.Where(x => x.Ime.ToLower().Contains(search.ImePrezime) ||
                                    x.Prezime.ToLower().Contains(search.ImePrezime));
            }

            var list = query.ToList();
            return Mapper.Map<List<Model.Korisnik>>(list);
        }

        public IList<Model.Korisnik> GetAll()
        {
            var database = Context.Korisniks.ToList();
            var list = Mapper.Map<IList<Model.Korisnik>>(database);

            return list;
        }

        public Model.Korisnik GetById(int id)
        {
            var entity = Context.Korisniks
                .FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                // Handle the case when no entity is found with the given Id
                return null;
            }

            // Map the retrieved entity to the corresponding Model.Korisnik object
            var korisnikModel = Mapper.Map<Model.Korisnik>(entity);

            return korisnikModel;
        }
        public async Task<Model.Korisnik> Insert (KorisnikUpsertRequest request)
        {
            var entity = Mapper.Map<Database.Korisnik>(request);

            entity.LozinkaSalt = PasswordHelper.GenerateSalt();
            entity.LozinkaHash = PasswordHelper.GenerateHash(entity.LozinkaSalt, request.Lozinka);

            await Context.Database.BeginTransactionAsync();

            Context.Korisniks.Add(entity);
            await Context.SaveChangesAsync();

           
            await Context.SaveChangesAsync();
            await Context.Database.CommitTransactionAsync();

            return Mapper.Map<Model.Korisnik>(entity);

        }

        public async Task<Model.Korisnik> Login(string korisnickoIme, string lozinka)
        {
            var entity = await Context.Korisniks.FirstOrDefaultAsync(x => x.KorisnickoIme == korisnickoIme);

            if (entity == null)
            {
                throw new Exception("Pogrešan username ili password");
            }

            var hash = PasswordHelper.GenerateHash(entity.LozinkaSalt, lozinka);

            if (hash != entity.LozinkaHash)
            {
                throw new Exception("Pogrešan username ili password");
            }

            return Mapper.Map<Model.Korisnik>(entity);
        }
    }
}
