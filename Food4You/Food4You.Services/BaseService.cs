using AutoMapper;
using Food4You.Model.SearchObjects;
using Food4You.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public class BaseService<T, TDb, TSearch> : IBaseService<T, TSearch> where T : class where TDb : class where TSearch : BaseSearchObject
    {
        public Food4YouContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public BaseService(Food4YouContext context, IMapper mapper)
        {
            Context = context;
            Mapper=mapper;
        }


        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var dbentity = Context.Set<TDb>().AsQueryable();

            dbentity = AddFilter(dbentity, search);

            dbentity = AddInclude(dbentity, search);

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true)
            {
                dbentity = dbentity.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = dbentity.ToList();

            return Mapper.Map<IEnumerable<T>>(list);

        }

        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }
        public virtual TDb AddIncludeforGetById(TDb query)
        {
            return query;
        }
        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TSearch search = null)
        {
            return query;
        }
       
        public virtual T GetById(int id)
        {
            var dbentity = Context.Set<TDb>();
            var result = dbentity.Find(id);

            result = AddIncludeforGetById(result);

            return Mapper.Map<T>(result);
        }
    }
}
