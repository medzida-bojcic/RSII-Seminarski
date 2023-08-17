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
    public class RecenzijeService : BaseCRUDService<Model.Recenzije, Recenzije, RecenzijaSearchObject, RecenzijaUpsertRequest, RecenzijaUpsertRequest>, IRecenzijeService
    {
        private readonly Food4YouContext context;
        private readonly IMapper mapper;

        public RecenzijeService(Food4YouContext _context, IMapper _mapper):base(_context, _mapper)
        {
            context = _context;
            mapper=_mapper;
        }
    }
}
