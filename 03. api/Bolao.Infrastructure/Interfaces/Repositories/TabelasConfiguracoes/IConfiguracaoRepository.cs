using Core.Repositories;
using Bolao.Domain.Entities.TabelasConfiguracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.TabelasConfiguracoes
{
    public interface IConfiguracaoRepository : IRepository<Configuracao, int>
    {
        Task<Configuracao> GetAsync();
    }
}
