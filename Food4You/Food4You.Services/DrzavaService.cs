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
    public class DrzavaService : BaseCRUDService<Model.Drzava, Database.Drzava, DrzavaSearchObject, DrzavaUpsertRequest, DrzavaUpsertRequest>, IDrzavaService
    {
        public DrzavaService(Food4YouContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Drzava> AddFilter(IQueryable<Drzava> query, DrzavaSearchObject search = null)
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
