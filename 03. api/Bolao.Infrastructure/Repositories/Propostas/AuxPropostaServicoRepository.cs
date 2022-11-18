using Dapper;
using Bolao.Domain.Entities.Propostas;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.Propostas
{
    public class AuxPropostaServicoRepository : IAuxPropostaServicoRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public AuxPropostaServicoRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public Task<IEnumerable<AuxPropostaServico>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuxPropostaServico> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuxPropostaServico> GetByUniqueKeyAsync(/*string idUsuario, int idLoja, */string guidProposta)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  aps.Id Id,
  aps.Valor_Projeto ValorProjeto,
  aps.Valor_Instalacao ValorInstalacao,
  aps.Id_Usuario IdUsuario,
  aps.Id_Loja IdLoja,
  aps.GuidProposta GuidProposta
from Tc_Sge_Valor_Repasse aps
where /*aps.Id_Usuario = @IdUsuario
  and aps.Id_Loja = @IdLoja
  and */aps.GuidProposta = @GuidProposta
order by aps.Valor_Projeto
";

            var result = await connection.QueryFirstOrDefaultAsync<AuxPropostaServico>(sql, new
            {
                //IdUsuario = idUsuario,
                //IdLoja = idLoja,
                GuidProposta = guidProposta
            });

            return result;
        }

        public async Task<int> CreateAsync(AuxPropostaServico entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Tc_Sge_Valor_Repasse
(
  Valor_Projeto,
  Valor_Instalacao,
  Id_Usuario,
  Id_Loja,
  GuidProposta
)
values
(
  @ValorProjeto,
  @ValorInstalacao,
  @IdUsuario,
  @IdLoja,
  @GuidProposta
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                ValorProjeto = entity.ValorProjeto,
                ValorInstalacao = entity.ValorInstalacao,
                IdUsuario = entity.IdUsuario,
                IdLoja = entity.IdLoja,
                GuidProposta = entity.GuidProposta
            });

            return result;
        }

        public async Task<int> UpdateAsync(AuxPropostaServico entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Valor_Repasse set
  Valor_Projeto = @ValorProjeto,
  Valor_Instalacao = @ValorInstalacao/*,
  Id_Usuario = @IdUsuario,
  Id_Loja = @IdLoja,
  GuidProposta = @GuidProposta*/
where Id = @Id
";

            var result = await connection.ExecuteAsync(sql, new
            {
                Id = entity.Id,
                ValorProjeto = entity.ValorProjeto,
                ValorInstalacao = entity.ValorInstalacao//,
                //IdUsuario = entity.IdUsuario,
                //IdLoja = entity.IdLoja,
                //GuidProposta = entity.GuidProposta
            });

            return result;
        }
    }
}
