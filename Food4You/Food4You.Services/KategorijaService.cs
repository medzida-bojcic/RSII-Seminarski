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
    public class KategorijaService : BaseCRUDService<Model.Kategorija, Database.Kategorija, KategorijaSearchObject, KategorijaUpsertRequest, KategorijaUpsertRequest>, IKategorijaService
    {
        private readonly Food4YouContext _context;
        private readonly IMapper _mapper;

        public KategorijaService(Food4YouContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper=mapper;
        }

        public override IEnumerable<Model.Kategorija> Get(KategorijaSearchObject search = null)
        {
            var query = _context.Kategorijas.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search.Naziv))
                query = query.Where(x => x.Naziv.Contains(search.Naziv));

            return _mapper.Map<IEnumerable<Model.Kategorija>>(query);
        }
    }
}
