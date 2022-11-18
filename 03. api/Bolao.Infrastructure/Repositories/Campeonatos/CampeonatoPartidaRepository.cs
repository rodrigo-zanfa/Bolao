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
    public class CampeonatoPartidaRepository : RepositoryBase, ICampeonatoPartidaRepository
    {
        public CampeonatoPartidaRepository(IApiSettingsAccessor apiSettingsAccessor) : base(apiSettingsAccessor)
        {

        }

        public Task<IEnumerable<CampeonatoPartida>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CampeonatoPartida> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CampeonatoPartida> GetByUniqueKeyAsync(DateTime dtPartida, int idCampeonatoTime1, int idCampeonatoTime2)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  cp.IdCampeonatoPartida,
  cp.DtPartida,
  cp.IdEstadio,
  cp.IdCampeonatoTime1,
  cp.IdCampeonatoTime2,
  cp.PlacarTime1,
  cp.PlacarTime2
from CampeonatoPartida cp
where cp.DtPartida = @DtPartida
  and cp.IdCampeonatoTime1 = @IdCampeonatoTime1
  and cp.IdCampeonatoTime2 = @IdCampeonatoTime2
";

            var result = await connection.QueryFirstOrDefaultAsync<CampeonatoPartida>(sql, new
            {
                DtPartida = dtPartida,
                IdCampeonatoTime1 = idCampeonatoTime1,
                IdCampeonatoTime2 = idCampeonatoTime2
            });

            return result;
        }

        public async Task<int> CreateAsync(CampeonatoPartida entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into CampeonatoPartida
(
  DtPartida,
  IdEstadio,
  IdCampeonatoTime1,
  IdCampeonatoTime2,
  PlacarTime1,
  PlacarTime2
)
values
(
  @DtPartida,
  @IdEstadio,
  @IdCampeonatoTime1,
  @IdCampeonatoTime2,
  @PlacarTime1,
  @PlacarTime2
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                DtPartida = entity.DtPartida,
                IdEstadio = entity.IdEstadio,
                IdCampeonatoTime1 = entity.IdCampeonatoTime1,
                IdCampeonatoTime2 = entity.IdCampeonatoTime2,
                PlacarTime1 = entity.PlacarTime1,
                PlacarTime2 = entity.PlacarTime2
            });

            return result;
        }

        public Task<int> UpdateAsync(CampeonatoPartida entity)
        {
            throw new NotImplementedException();
        }
    }
}
