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
    public class TimeRepository : RepositoryBase, ITimeRepository
    {
        public TimeRepository(IApiSettingsAccessor apiSettingsAccessor) : base(apiSettingsAccessor)
        {

        }

        public Task<IEnumerable<Time>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Time> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Time> GetByIdAuxAsync(int idAux)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  t.IdTime,
  t.IdTimeAux,
  t.Nome,
  t.Sigla,
  t.UrlImagem
from Time t
where t.IdTimeAux = @IdTimeAux
order by t.IdTime
";

            var result = await connection.QueryFirstOrDefaultAsync<Time>(sql, new
            {
                IdTimeAux = idAux
            });

            return result;
        }

        public async Task<int> CreateAsync(Time entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Time
(
  IdTimeAux,
  Nome,
  Sigla,
  UrlImagem
)
values
(
  @IdTimeAux,
  @Nome,
  @Sigla,
  @UrlImagem
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdTimeAux = entity.IdTimeAux,
                Nome = entity.Nome,
                Sigla = entity.Sigla,
                UrlImagem = entity.UrlImagem
            });

            return result;
        }

        public Task<int> UpdateAsync(Time entity)
        {
            throw new NotImplementedException();
        }
    }
}
