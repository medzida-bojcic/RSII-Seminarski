using AutoMapper;
using Food4You.Model.Requests;
using Food4You.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public class UplataService : BaseCRUDService<Model.Uplata, Database.Uplatum, UplataSearchObject, UplataUpsertRequest, UplataUpsertRequest>, IUplataService
    {
        private readonly Food4YouContext _context;
        private readonly IMapper _mapper;

        public UplataService(Food4YouContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override List<Model.Uplata> Get(UplataSearchObject search)
        {
            var query = _context.Uplata.AsQueryable();

            if (search.KorisnikId != 0)
            {
                query = query.Where(x => x.KorisnikId == search.KorisnikId);
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Uplata>>(list);
        }

        public async Task<Model.Uplata> InsertAsync(UplataUpsertRequest request)
        {
            var uplata = new Uplatum()
            {
                Iznos = (decimal)request.Iznos,
                BrojTransakcije = request.BrojTransakcije,
                DatumTransakcije = DateTime.Parse(request.DatumTransakcije),
                KorisnikId = request.KorisnikId
            };

            await _context.Uplata.AddAsync(uplata);
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Uplata>(uplata);
        }
    }
}
