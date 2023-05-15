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
    public class UlogeService : BaseService<Model.Uloge, Database.Uloga, UlogeSearchObject>, IUlogeService
    {
        public UlogeService(Food4YouContext context, IMapper mapper) : base(context, mapper)
        {
            
        }
        public override IQueryable<Uloga> AddFilter(IQueryable<Uloga> query, UlogeSearchObject search = null)
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
