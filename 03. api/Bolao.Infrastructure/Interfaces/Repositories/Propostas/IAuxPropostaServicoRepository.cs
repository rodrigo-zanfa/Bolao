using Core.Repositories;
using Bolao.Domain.Entities.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Propostas
{
    public interface IAuxPropostaServicoRepository : IRepository<AuxPropostaServico, int>
    {
        Task<AuxPropostaServico> GetByUniqueKeyAsync(/*string idUsuario, int idLoja, */string guidProposta);
    }
}
