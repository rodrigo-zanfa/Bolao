using Bolao.Domain.Entities.Campeonatos;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.Interfaces.Repositories.Campeonatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.Campeonatos
{
    public class CampeonatoRepository : RepositoryBase, ICampeonatoRepository
    {
        public CampeonatoRepository(IApiSettingsAccessor apiSettingsAccessor) : base(apiSettingsAccessor)
        {

        }

        public Task<IEnumerable<Campeonato>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Campeonato> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Campeonato entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Campeonato entity)
        {
            throw new NotImplementedException();
        }
    }
}
