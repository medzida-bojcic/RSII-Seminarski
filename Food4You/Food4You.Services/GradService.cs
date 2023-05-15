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
    public class GradService : BaseCRUDService<Model.Grad, Database.Grad, GradSearchObject, GradUpsertRequest, GradUpsertRequest>, IGradService
    {
        private readonly Food4YouContext _context;
        private readonly IMapper _mapper;

        public GradService(Food4YouContext context, IMapper mapper) : base (context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override IQueryable<Grad> AddFilter(IQueryable<Grad> query, GradSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                filter = filter.Where(w => w.Naziv.Contains(search.Naziv));
            }

            return filter;
        }
    }
}
