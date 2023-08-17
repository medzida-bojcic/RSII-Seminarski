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
    public class StatusNarudzbeService : BaseService<Model.StatusNarudzbe,Database.StatusNarudzbe, StatusNarudzbeSearchObject>, IStatusNarudzbeService
    {
        private readonly Food4YouContext context;
        private readonly IMapper mapper;

        public StatusNarudzbeService(Food4YouContext _context, IMapper _mapper) : base(_context, _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public override List<Model.StatusNarudzbe> Get(StatusNarudzbeSearchObject request)
        {
            var query = context.StatusNarudzbes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Naziv))
            {
                query = query.Where(x => x.Naziv.Contains(request.Naziv));
            }

            var list = query.ToList();

            return mapper.Map<List<Model.StatusNarudzbe>>(list);
        }
    }
}
