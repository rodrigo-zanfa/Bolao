using Core.Repositories;
using Bolao.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Produtos
{
    public interface IProdutoRepository : IRepository<Produto, int>
    {
        Task<Produto> GetByCodigoAsync(string codigo);
    }
}
