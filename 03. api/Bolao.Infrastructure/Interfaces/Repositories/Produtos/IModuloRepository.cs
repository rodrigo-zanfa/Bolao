﻿using Core.Repositories;
using Bolao.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Produtos
{
    public interface IModuloRepository : IRepository<Modulo, int>
    {
        Task<Modulo> GetByCodigoAsync(string codigo);
        Task<int> CreateAsync(Produto entity);
        Task<int> UpdateAsync(Produto entity);
    }
}
