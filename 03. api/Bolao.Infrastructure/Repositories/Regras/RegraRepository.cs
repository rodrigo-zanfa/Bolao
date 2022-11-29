using Bolao.Domain.Entities.Regras;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.Regras;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.Regras
{
    public class RegraRepository : RepositoryBase, IRegraRepository
    {
        public RegraRepository(IApiSettingsAccessor apiSettingsAccessor) : base(apiSettingsAccessor)
        {

        }

        public Task<IEnumerable<Regra>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Regra>> GetAllByBolaoAsync(int idBolao)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  r.IdRegra,
  r.Descricao,
  r.DescricaoDetalhada,
  r.Pontuacao,
  r.Ordem,
  r.Status
from Regra r
  inner join BolaoRegra br on r.IdRegra = br.IdRegra
where br.IdBolao = @IdBolao
order by r.Ordem
";

            var result = await connection.QueryAsync<Regra>(sql, new
            {
                IdBolao = idBolao
            });

            return result;
        }

        public Task<Regra> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Regra entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Regra entity)
        {
            throw new NotImplementedException();
        }
    }
}
