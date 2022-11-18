using Core.Services;
using Bolao.Domain.Entities.TiposFixacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.TiposFixacoes
{
    public interface ITipoFixacaoService : IService<TipoFixacao, int>
    {
        Task<IEnumerable<TipoFixacao>> GetAllByMarcaEstruturaAsync(int idMarcaEstrutura);
    }
}
