using AutoMapper;
using Food4You.Model.Requests;
using Food4You.Services.Database;
using Food4You.Services.NarudzbaStateMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public class NarudzbaService : BaseCRUDService<Model.Narudzba, Narudzba, NarudzbaSearchObject, NarudzbaUpsertRequest, NarudzbaUpsertRequest>, INarudzbaService
    {
        private readonly Food4YouContext context;
        private readonly IMapper mapper;
        public BaseState baseState { get; set; }
        public NarudzbaService(Food4YouContext _context, IMapper _mapper, BaseState _state) : base(_context, _mapper)
        {
            context = _context; 
            mapper = _mapper;
            baseState = _state;
        }

        public override Model.Narudzba GetById(int id)
        {
            var result = context.Narudzbas.Include(x => x.Korisnik)
                                        .Include(x => x.StatusNarudzbe)
                                        .FirstOrDefault(x => x.Id == id);

            return mapper.Map<Model.Narudzba>(result);
        }

        public override List<Model.Narudzba> Get(NarudzbaSearchObject search)
        {
            var query = context.Narudzbas.AsQueryable();

            if (search.Id != 0)
                query = query.Where(x => x.Id == search.Id);

            if (search.DatumNarudzbe != null)
                query = query.Where(x => x.DatumNarudzbe == search.DatumNarudzbe);

            if (search.StatusNarudzbeId != 0)
                query = query.Where(x => x.StatusNarudzbeId == search.StatusNarudzbeId);

            if (search.KorisnikId != 0)
                query = query.Where(x => x.KorisnikId == search.KorisnikId);

            var list = query.Include(x => x.Korisnik)
                          .Include(x => x.StatusNarudzbe)
                          .ToList();

            return mapper.Map<List<Model.Narudzba>>(list);
        }

        public async Task<Model.Narudzba> UpdateAsync(int id, NarudzbaUpsertRequest request)
        {
            var entity = context.Narudzbas.Find(id);
            entity.StatusNarudzbeId = request.StatusNarudzbeId;

            await context.SaveChangesAsync();
            return mapper.Map<Model.Narudzba>(entity);
        }
        public Task<Model.Narudzba> Insert(NarudzbaUpsertRequest insert)
        {
            var state = baseState.CreateState("Initial");

            return state.Insert(insert);
        }
        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await context.Narudzbas.FindAsync(id);
            var state = baseState.CreateState(entity?.StateMachine ?? "Initial");
            return await state.AllowedActions();
        }

        public async Task<Model.Narudzba> Cancel(int id)
        {
            var entity = await context.Narudzbas.FindAsync(id);
            if (entity == null)
            {
                throw new UserException($"Order {id} does not exist");
            }
            var state = baseState.CreateState(entity.StateMachine);

            return await state.Cancel(id);
        }
        public async Task<Model.Narudzba> Accept(int id)
        {
            var entity = await context.Narudzbas.FindAsync(id);
            if (entity == null)
            {
                throw new UserException($"Order {id} does not exist");
            }
            var state = baseState.CreateState(entity.StateMachine);

            return await state.Accept(id);
        }
        public async Task<Model.Narudzba> InProgress(int id)
        {
            var entity = await context.Narudzbas.FindAsync(id);
            if (entity == null)
            {
                throw new UserException($"Order {id} does not exist");
            }
            var state = baseState.CreateState(entity.StateMachine);

            return await state.InProgress(id);
        }
        public async Task<Model.Narudzba> Finish(int id)
        {
            var entity = await context.Narudzbas.FindAsync(id);
            if (entity == null)
            {
                throw new UserException($"Order {id} does not exist");
            }
            var state = baseState.CreateState(entity.StateMachine);

            return await state.Finish(id);
        }
        public async Task<Model.Narudzba> Deliver(int id)
        {
            var entity = await context.Narudzbas.FindAsync(id);
            if (entity == null)
            {
                throw new UserException($"Order {id} does not exist");
            }
            var state = baseState.CreateState(entity.StateMachine);

            return await state.Deliver(id);
        }
    }
}
