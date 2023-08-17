using AutoMapper;
using Food4You.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services.NarudzbaStateMachine
{
    public class CanceledOrderState : BaseState
    {
        public CanceledOrderState(IServiceProvider serviceProvider, IMapper mapper, Food4YouContext context) : base(serviceProvider, mapper, context)
        {

        }
        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("None");

            return list;
        }
    }
}
