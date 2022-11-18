using Core.Services;
using Bolao.Domain.Entities.TabelasConfiguracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.TabelasConfiguracoes
{
    public interface IConfiguracaoService : IService<Configuracao, int>
    {
        Task<Configuracao> GetAsync();
    }
}
