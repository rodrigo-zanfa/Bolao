using Dapper;
using Bolao.Domain.Entities.TabelasConfiguracoes;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.TabelasConfiguracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.TabelasConfiguracoes
{
    public class ConfiguracaoRepository : IConfiguracaoRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public ConfiguracaoRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public Task<IEnumerable<Configuracao>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Configuracao> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  c.Id IdConfiguracao,
  c.Qtd_Dia_Vencimento_Proposta QuantidadeDiasVencimentoProposta,
  c.Frete PorcentagemFrete,
  c.Imposto PorcentagemImposto,
  c.Inadimplencia PorcentagemInadimplencia,
  c.Marketing PorcentagemMarketing,
  c.Garantia PorcentagemGarantia,
  c.Seguro PorcentagemSeguro
from Tc_Sge_Config c
where c.Id = @IdConfiguracao
order by c.Id
";

            var result = await connection.QueryFirstOrDefaultAsync<Configuracao>(sql, new
            {
                IdConfiguracao = id
            });

            return result;
        }

        public async Task<Configuracao> GetAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  c.Id IdConfiguracao,
  c.Qtd_Dia_Vencimento_Proposta QuantidadeDiasVencimentoProposta,
  c.Frete PorcentagemFrete,
  c.Imposto PorcentagemImposto,
  c.Inadimplencia PorcentagemInadimplencia,
  c.Marketing PorcentagemMarketing,
  c.Garantia PorcentagemGarantia,
  c.Seguro PorcentagemSeguro
from Tc_Sge_Config c
order by c.Id
";

            var result = await connection.QueryFirstOrDefaultAsync<Configuracao>(sql);

            return result;
        }

        public Task<int> CreateAsync(Configuracao entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Configuracao entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Config set
  Qtd_Dia_Vencimento_Proposta = @QuantidadeDiasVencimentoProposta,
  Frete = @PorcentagemFrete,
  Imposto = @PorcentagemImposto,
  Inadimplencia = @PorcentagemInadimplencia,
  Marketing = @PorcentagemMarketing,
  Garantia = @PorcentagemGarantia,
  Seguro = @PorcentagemSeguro
where Id = @IdConfiguracao
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdConfiguracao = entity.IdConfiguracao,
                QuantidadeDiasVencimentoProposta = entity.QuantidadeDiasVencimentoProposta,
                PorcentagemFrete = entity.PorcentagemFrete,
                PorcentagemImposto = entity.PorcentagemImposto,
                PorcentagemInadimplencia = entity.PorcentagemInadimplencia,
                PorcentagemMarketing = entity.PorcentagemMarketing,
                PorcentagemGarantia = entity.PorcentagemGarantia,
                PorcentagemSeguro = entity.PorcentagemSeguro
            });

            return result;
        }
    }
}
