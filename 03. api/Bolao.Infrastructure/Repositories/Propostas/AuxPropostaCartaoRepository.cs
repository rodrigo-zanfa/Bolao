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
    public class AuxPropostaCartaoRepository : IAuxPropostaCartaoRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public AuxPropostaCartaoRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public Task<IEnumerable<AuxPropostaCartao>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuxPropostaCartao> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuxPropostaCartao> GetByUniqueKeyAsync(/*string idUsuario, int idLoja, */string guidProposta)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  apc.Id_Proposta_Cartao_Aux Id,
  apc.Id_Operadora IdOperadora,
  apc.QntVezes QuantidadeParcelas,
  apc.Taxa Taxa,
  apc.Id_Usuario IdUsuario,
  apc.Id_Loja IdLoja,
  apc.GuidProposta GuidProposta
from Tc_Sge_Proposta_Cartao_Aux apc
where /*apc.Id_Usuario = @IdUsuario
  and apc.Id_Loja = @IdLoja
  and */apc.GuidProposta = @GuidProposta
order by apc.Id_Operadora
";

            var result = await connection.QueryFirstOrDefaultAsync<AuxPropostaCartao>(sql, new
            {
                //IdUsuario = idUsuario,
                //IdLoja = idLoja,
                GuidProposta = guidProposta
            });

            return result;
        }

        public async Task<int> CreateAsync(AuxPropostaCartao entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Tc_Sge_Proposta_Cartao_Aux
(
  Id_Operadora,
  QntVezes,
  Taxa,
  Id_Usuario,
  Id_Loja,
  GuidProposta
)
values
(
  @IdOperadora,
  @QuantidadeParcelas,
  @Taxa,
  @IdUsuario,
  @IdLoja,
  @GuidProposta
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdOperadora = entity.IdOperadora,
                QuantidadeParcelas = entity.QuantidadeParcelas,
                Taxa = entity.Taxa,
                IdUsuario = entity.IdUsuario,
                IdLoja = entity.IdLoja,
                GuidProposta = entity.GuidProposta
            });

            return result;
        }

        public async Task<int> UpdateAsync(AuxPropostaCartao entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Proposta_Cartao_Aux set
  Id_Operadora = @IdOperadora,
  QntVezes = @QuantidadeParcelas,
  Taxa = @Taxa/*,
  Id_Usuario = @IdUsuario,
  Id_Loja = @IdLoja,
  GuidProposta = @GuidProposta*/
where Id_Proposta_Cartao_Aux = @Id
";

            var result = await connection.ExecuteAsync(sql, new
            {
                Id = entity.Id,
                IdOperadora = entity.IdOperadora,
                QuantidadeParcelas = entity.QuantidadeParcelas,
                Taxa = entity.Taxa//,
                //IdUsuario = entity.IdUsuario,
                //IdLoja = entity.IdLoja,
                //GuidProposta = entity.GuidProposta
            });

            return result;
        }
    }
}
