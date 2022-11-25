using Bolao.Domain.Entities.Boloes;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.Boloes;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.Boloes
{
    public class BolaoPalpiteRepository : RepositoryBase, IBolaoPalpiteRepository
    {
        public BolaoPalpiteRepository(IApiSettingsAccessor apiSettingsAccessor) : base(apiSettingsAccessor)
        {

        }

        public Task<IEnumerable<BolaoPalpite>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BolaoPalpite> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BolaoPalpite> GetByUniqueKeyAsync(int idBolaoUsuario, int idCampeonatoPartida)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  bp.IdBolaoPalpite,
  bp.IdBolaoUsuario,
  bp.IdCampeonatoPartida,
  bp.PlacarTime1,
  bp.PlacarTime2,
  bp.DtCadastro,
  bp.DtAlteracao,
  bp.DtPontuacao,
  bp.IdRegra,
  bp.Pontuacao
from BolaoPalpite bp
where bp.IdBolaoUsuario = @IdBolaoUsuario
  and bp.IdCampeonatoPartida = @IdCampeonatoPartida
";

            var result = await connection.QueryFirstOrDefaultAsync<BolaoPalpite>(sql, new
            {
                IdBolaoUsuario = idBolaoUsuario,
                IdCampeonatoPartida = idCampeonatoPartida
            });

            return result;
        }

        public async Task<int> CreateAsync(BolaoPalpite entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into BolaoPalpite
(
  IdBolaoUsuario,
  IdCampeonatoPartida,
  PlacarTime1,
  PlacarTime2,
  DtCadastro--,
  --DtAlteracao,
  --DtPontuacao,
  --IdRegra,
  --Pontuacao
)
values
(
  @IdBolaoUsuario,
  @IdCampeonatoPartida,
  @PlacarTime1,
  @PlacarTime2,
  @DtCadastro--,
  --@DtAlteracao,
  --@DtPontuacao,
  --@IdRegra,
  --@Pontuacao
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdBolaoUsuario = entity.IdBolaoUsuario,
                IdCampeonatoPartida = entity.IdCampeonatoPartida,
                PlacarTime1 = entity.PlacarTime1,
                PlacarTime2 = entity.PlacarTime2,
                DtCadastro = DateTime.Now,  // entity.DtCadastro
                //DtAlteracao = DateTime.Now,  // entity.DtAlteracao
                //DtPontuacao = DateTime.Now,  // entity.DtPontuacao
                //IdRegra = entity.IdRegra,
                //Pontuacao = entity.Pontuacao
            });

            return result;
        }

        public async Task<int> UpdateAsync(BolaoPalpite entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update BolaoPalpite set
  IdBolaoUsuario = @IdBolaoUsuario,
  IdCampeonatoPartida = @IdCampeonatoPartida,
  PlacarTime1 = @PlacarTime1,
  PlacarTime2 = @PlacarTime2,
  --DtCadastro = @DtCadastro,
  DtAlteracao = @DtAlteracao--,
  --DtPontuacao = @DtPontuacao,
  --IdRegra = @IdRegra,
  --Pontuacao = @Pontuacao
where IdBolaoPalpite = @IdBolaoPalpite
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdBolaoPalpite = entity.IdBolaoPalpite,
                IdBolaoUsuario = entity.IdBolaoUsuario,
                IdCampeonatoPartida = entity.IdCampeonatoPartida,
                PlacarTime1 = entity.PlacarTime1,
                PlacarTime2 = entity.PlacarTime2,
                //DtCadastro = DateTime.Now,  // entity.DtCadastro
                DtAlteracao = DateTime.Now,  // entity.DtAlteracao
                //DtPontuacao = DateTime.Now,  // entity.DtPontuacao
                //IdRegra = entity.IdRegra,
                //Pontuacao = entity.Pontuacao
            });

            return result;
        }
    }
}
