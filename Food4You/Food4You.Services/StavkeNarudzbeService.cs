using AutoMapper;
using Food4You.Model.Requests;
using Food4You.Services.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public class StavkeNarudzbeService : BaseCRUDService<Model.NarudzbaStavke, Database.NarudzbaStavke, NarudzbaStavkeSearchObject, NarudzbaStavkeUpsertRequest, NarudzbaStavkeUpsertRequest>, IStavkeNarudzbeService
    {
        private readonly Food4YouContext context;
        private readonly IMapper mapper;

        public StavkeNarudzbeService(Food4YouContext _context, IMapper _mapper) : base(_context, _mapper)
        {
            context= _context;
            mapper= _mapper;
        }

       /* public override List<Model.NarudzbaStavke> Get(NarudzbaStavkeSearchObject search)
        {
            var query = context.NarudzbaStavkes.AsQueryable();

            if (search.NarudzbaId != 0)
            {
                query = query.Where(x => x.NarudzbaId == search.NarudzbaId);
            }
            if (search.KorisnikId != 0)
            {
                query = query.Where(x => x.Narudzba.KorisnikId == search.KorisnikId);
            }
            if (search.MeniId != 0)
            {
                query = query.Where(x => x.MeniId == search.MeniId);
            }
            var list = query.Include(x => x.Meni).ToList();

            var result = mapper.Map<List<Model.NarudzbaStavke>>(list);

            return result;
        }*/

        [HttpPost]
        public async Task<List<Model.NarudzbaStavke>> InsertAsync(List<NarudzbaStavkeUpsertRequest> request)
        {
            //var result = request.Select(i => new NarudzbaStavke
            //{
            //    MeniId = i.Meni.Id,
            //    Cijena = i.Cijena,
            //    Kolicina = i.Kolicina,
            //    NarudzbaId = i.NarudzbaId,
            //}).ToList();

            //await context.NarudzbaStavkes.AddRangeAsync(result);
            //await context.SaveChangesAsync();

            //var model = result.Select(i => new Model.NarudzbaStavke
            //{
            //    Id = i.Id,
            //    NarudzbaId = i.NarudzbaId,
            //    MeniId = i.MeniId,
            //    Kolicina = i.Kolicina,
            //    Cijena = i.Cijena,
            //}).ToList();

            //return model;

            var entities = request.Select(i => mapper.Map<NarudzbaStavke>(i)).ToList();

            await context.NarudzbaStavkes.AddRangeAsync(entities);
            await context.SaveChangesAsync();

            var model = entities.Select(i => mapper.Map<Model.NarudzbaStavke>(i)).ToList();

            return model;
        }

    }
}
