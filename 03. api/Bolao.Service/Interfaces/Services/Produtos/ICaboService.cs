﻿using Core.Services;
using Bolao.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Produtos
{
    public interface ICaboService : IService<Cabo, int>
    {
        Task<Cabo> GetByCodigoAsync(string codigo);
    }
}
