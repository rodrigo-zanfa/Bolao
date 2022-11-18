using Bolao.Domain.Entities.Campeonatos;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.Campeonatos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.Campeonatos
{
    public class CampeonatoTimeRepository : RepositoryBase, ICampeonatoTimeRepository
    {
        public CampeonatoTimeRepository(IApiSettingsAccessor apiSettingsAccessor) : base(apiSettingsAccessor)
        {

        }

        public Task<IEnumerable<CampeonatoTime>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CampeonatoTime> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CampeonatoTime> GetByUniqueKeyAsync(int idCampeonato, int idTime)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  ct.IdCampeonatoTime,
  ct.IdCampeonato,
  ct.IdTime
from CampeonatoTime ct
where ct.IdCampeonato = @IdCampeonato
  and ct.IdTime = @IdTime
";

            var result = await connection.QueryFirstOrDefaultAsync<CampeonatoTime>(sql, new
            {
                IdCampeonato = idCampeonato,
                IdTime = idTime
            });

            return result;
        }

        public Task<int> CreateAsync(CampeonatoTime entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(CampeonatoTime entity)
        {
            throw new NotImplementedException();
        }
    }
}
