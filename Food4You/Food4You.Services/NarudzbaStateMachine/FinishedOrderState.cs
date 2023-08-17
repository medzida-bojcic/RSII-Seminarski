﻿using AutoMapper;
using Food4You.Services.Database;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services.NarudzbaStateMachine
{
    public class FinishedOrderState : BaseState
    {
        public FinishedOrderState(IServiceProvider serviceProvider, IMapper mapper, Food4YouContext context) : base(serviceProvider, mapper, context)
        {

        }
        public override async Task<Model.Narudzba> Deliver(int id)
        {
            var entity = await _context.Narudzbas.FindAsync(id);
            if (entity == null)
            {
                throw new UserException($"Order {id} does not exist");
            }
            entity.StateMachine = "Delivered";
            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Narudzba>(entity);
        }
        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions();

            list.Add("Deliver");

            return list;
        }
    }
}
