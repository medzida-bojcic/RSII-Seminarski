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
        //public Food4YouContext Context { get; set; }
        //public  IMapper Mapper { get; set; }

        public KorisniciService(Food4YouContext context, IMapper mapper) : base(context, mapper)
        {
            Context=context;
            Mapper=mapper;  
        }

        //public override async Task BeforeInsert(Korisnik entity, KorisnikUpsertRequest insert)
        //{
        //    entity.LozinkaSalt = PasswordHelper.GenerateSalt();
        //    entity.LozinkaHash = PasswordHelper.GenerateHash(entity.LozinkaSalt, insert.Lozinka);
        //}


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

        public override IQueryable<Korisnik> AddInclude(IQueryable<Korisnik> query, KorisnikSearchRequest? search = null)
        {
            if (search?.IsUlogeIncluded == true)
            {
                query = query.Include("KorisnikUlogas.Uloga");
            }
            return base.AddInclude(query, search);
        }
        public async Task<Model.Korisnik> Login(string korisnickoIme, string lozinka)
        {
            var entity = await Context.Korisniks.Include("KorisnikUlogas.Uloga").FirstOrDefaultAsync(x => x.KorisnickoIme == korisnickoIme);

            if (entity == null)
            {
                return null;
            }

            var hash = PasswordHelper.GenerateHash(entity.LozinkaSalt, lozinka);

            if (hash != entity.LozinkaHash)
            {
                return null;
            }

            return Mapper.Map<Model.Korisnik>(entity);
        }
    }
}
