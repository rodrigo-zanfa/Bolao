using Bolao.Domain.Entities.Propostas;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.Interfaces.Repositories.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.Propostas
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public PropostaRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public Task<IEnumerable<Proposta>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Proposta> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Proposta entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Proposta entity)
        {
            throw new NotImplementedException();
        }
    }
}
