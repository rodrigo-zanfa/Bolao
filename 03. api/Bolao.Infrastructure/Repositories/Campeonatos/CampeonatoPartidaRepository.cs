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

        public async Task<CampeonatoPartida> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  cp.IdCampeonatoPartida,
  cp.DtPartida,
  cp.IdEstadio,
  cp.IdCampeonatoTime1,
  cp.IdCampeonatoTime2,
  cp.Peso,
  cp.PlacarTime1,
  cp.PlacarTime2
from CampeonatoPartida cp
where cp.IdCampeonatoPartida = @IdCampeonatoPartida
";

            var result = await connection.QueryFirstOrDefaultAsync<CampeonatoPartida>(sql, new
            {
                IdCampeonatoPartida = id
            });

            return result;
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
  cp.Peso,
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

        public async Task<CampeonatoPartida> GetByUniqueKeyAsync(int idCampeonatoTime1, int idCampeonatoTime2)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  cp.IdCampeonatoPartida,
  cp.DtPartida,
  cp.IdEstadio,
  cp.IdCampeonatoTime1,
  cp.IdCampeonatoTime2,
  cp.Peso,
  cp.PlacarTime1,
  cp.PlacarTime2
from CampeonatoPartida cp
where cp.IdCampeonatoTime1 = @IdCampeonatoTime1
  and cp.IdCampeonatoTime2 = @IdCampeonatoTime2
";

            var result = await connection.QueryFirstOrDefaultAsync<CampeonatoPartida>(sql, new
            {
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
  Peso,
  PlacarTime1,
  PlacarTime2
)
values
(
  @DtPartida,
  @IdEstadio,
  @IdCampeonatoTime1,
  @IdCampeonatoTime2,
  @Peso,
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
                Peso = entity.Peso,
                PlacarTime1 = entity.PlacarTime1,
                PlacarTime2 = entity.PlacarTime2
            });

            return result;
        }

        public async Task<int> UpdateAsync(CampeonatoPartida entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update CampeonatoPartida set
  DtPartida = @DtPartida,
  IdEstadio = @IdEstadio,
  IdCampeonatoTime1 = @IdCampeonatoTime1,
  IdCampeonatoTime2 = @IdCampeonatoTime2,
  Peso = @Peso,
  PlacarTime1 = @PlacarTime1,
  PlacarTime2 = @PlacarTime2
where IdCampeonatoPartida = @IdCampeonatoPartida
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdCampeonatoPartida = entity.IdCampeonatoPartida,
                DtPartida = entity.DtPartida,
                IdEstadio = entity.IdEstadio,
                IdCampeonatoTime1 = entity.IdCampeonatoTime1,
                IdCampeonatoTime2 = entity.IdCampeonatoTime2,
                Peso = entity.Peso,
                PlacarTime1 = entity.PlacarTime1,
                PlacarTime2 = entity.PlacarTime2
            });

            return result;
        }
    }
}
