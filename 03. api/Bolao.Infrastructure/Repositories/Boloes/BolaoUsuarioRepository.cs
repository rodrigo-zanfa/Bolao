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
    public class BolaoUsuarioRepository : RepositoryBase, IBolaoUsuarioRepository
    {
        public BolaoUsuarioRepository(IApiSettingsAccessor apiSettingsAccessor) : base(apiSettingsAccessor)
        {

        }

        public Task<IEnumerable<BolaoUsuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BolaoUsuario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BolaoUsuario> GetByUniqueKeyAsync(int idBolao, int idUsuario)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  bu.IdBolaoUsuario,
  bu.IdBolao,
  bu.IdUsuario,
  bu.DtInscricao
from BolaoUsuario bu
where bu.IdBolao = @IdBolao
  and bu.IdUsuario = @IdUsuario
";

            var result = await connection.QueryFirstOrDefaultAsync<BolaoUsuario>(sql, new
            {
                IdBolao = idBolao,
                IdUsuario = idUsuario
            });

            return result;
        }

        public async Task<int> CreateAsync(BolaoUsuario entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into BolaoUsuario
(
  IdBolao,
  IdUsuario,
  DtInscricao
)
values
(
  @IdBolao,
  @IdUsuario,
  @DtInscricao
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdBolao = entity.IdBolao,
                IdUsuario = entity.IdUsuario,
                DtInscricao = DateTime.Now  // entity.DtInscricao
            });

            return result;
        }

        public Task<int> UpdateAsync(BolaoUsuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
