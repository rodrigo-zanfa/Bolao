using Core.Repositories;
using Bolao.Domain.Commands.Propostas;
using Bolao.Domain.Entities.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Propostas
{
    public interface IAuxPropostaGridRepository : IRepository<AuxPropostaGrid, int>
    {
        Task<IEnumerable<AuxPropostaGrid>> GetAllByGuidAsync(string guidProposta);
        Task<AuxPropostaGrid> GetByCodigoAsync(string guidProposta, string codigo);
        Task<IEnumerable<AuxPropostaGrid>> CalcularItensAsync(CalcularItensCommand command);
        Task<int> UpdateValoresCalculadosAsync(AuxPropostaGrid entity);
        Task<int> UpdateValoresCalculadosTotaisAsync(string guidProposta, double valorNFServicoProjeto, double valorNFServicoInstalacao, double valorBrutoServicos, double valorRepasseLiquidoServicos, double valorAdicionalDevidoRepasseServicos,
            double valorRepasseLiquidoComissao, double valorAdicionalDevidoRepasseComissao, double valorAdicionalDevidoRepasseServicosSemCartao, double valorRepasseLiquidoComissaoSemCartao, double valorAdicionalDevidoRepasseComissaoSemCartao);
        Task<int> DeleteAsync(int id);
    }
}
