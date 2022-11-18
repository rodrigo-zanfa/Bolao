using Core.Commands;
using Core.Services;
using Bolao.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Produtos
{
    public interface IProdutoService : IService<Produto, int>
    {
        Task<Produto> GetByCodigoAsync(string codigo);
        Task<ICommandResult> UpdateStatusAsync(int id, string ativo, string usuarioAlteracao);
    }
}
