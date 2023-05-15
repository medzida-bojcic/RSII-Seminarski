﻿using Food4You.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food4You.Services
{
    public interface IGradService : ICRUDService<Model.Grad, GradSearchObject, GradUpsertRequest, GradUpsertRequest>
    {
    }
}
