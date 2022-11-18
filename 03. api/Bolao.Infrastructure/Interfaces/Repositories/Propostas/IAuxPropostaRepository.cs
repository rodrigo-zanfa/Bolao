using Core.Repositories;
using Bolao.Domain.Entities.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Propostas
{
    public interface IAuxPropostaRepository : IRepository<AuxProposta, int>
    {
        Task<AuxProposta> GetByGuidAsync(string guidProposta);
        Task<(double porcentagemDistribuidor, double porcentagemLojista)> GetMargemDistribuidorLojistaAsync(int idLoja);
    }
}
