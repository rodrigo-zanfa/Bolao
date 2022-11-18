using Core.Repositories;
using Bolao.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Produtos
{
    public interface IEstruturaRepository : IRepository<Estrutura, int>
    {
        Task<Estrutura> GetByCodigoAsync(string codigo);
        Task<int> SaveAsync(Produto entity);
    }
}
