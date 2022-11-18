using Core.Repositories;
using Bolao.Domain.Entities.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Propostas
{
    public interface IAuxPropostaCartaoRepository : IRepository<AuxPropostaCartao, int>
    {
        Task<AuxPropostaCartao> GetByUniqueKeyAsync(/*string idUsuario, int idLoja, */string guidProposta);
    }
}
