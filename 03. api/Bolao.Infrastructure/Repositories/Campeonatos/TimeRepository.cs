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
  t.IdAux,
  t.Nome,
  t.Sigla,
  t.UrlImagem
from Time t
where t.IdAux = @IdAux
order by t.IdTime
";

            var result = await connection.QueryFirstOrDefaultAsync<Time>(sql, new
            {
                IdAux = idAux
            });

            return result;
        }

        public async Task<Time> GetBySiglaAsync(string sigla)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  t.IdTime,
  t.IdAux,
  t.Nome,
  t.Sigla,
  t.UrlImagem
from Time t
where t.Sigla = @Sigla
order by t.IdTime
";

            var result = await connection.QueryFirstOrDefaultAsync<Time>(sql, new
            {
                Sigla = sigla
            });

            return result;
        }

        public async Task<int> CreateAsync(Time entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Time
(
  IdAux,
  Nome,
  Sigla,
  UrlImagem
)
values
(
  @IdAux,
  @Nome,
  @Sigla,
  @UrlImagem
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdAux = entity.IdAux,
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
