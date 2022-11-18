using Core.Repositories;
using Bolao.Domain.Entities.TiposFixacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.TiposFixacoes
{
    public interface ITipoFixacaoRepository : IRepository<TipoFixacao, int>
    {
        Task<IEnumerable<TipoFixacao>> GetAllByMarcaEstruturaAsync(int idMarcaEstrutura);
    }
}
