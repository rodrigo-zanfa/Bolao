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
    public class CartaoCreditoRepository : ICartaoCreditoRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public CartaoCreditoRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public async Task<IEnumerable<CartaoCredito>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  c.Id IdCartaoCredito,
  c.Descricao Bandeira,
  c.FormPagto1P FormatoPagamentoUmaParcela,
  c.FormPagto2a6P FormatoPagamentoDuasAteSeisParcelas,
  c.FormPagto7a12P FormatoPagamentoSeteAteDozeParcelas,
  c.Taxa01X,
  c.Taxa02X,
  c.Taxa03X,
  c.Taxa04X,
  c.Taxa05X,
  c.Taxa06X,
  c.Taxa07X,
  c.Taxa08X,
  c.Taxa09X,
  c.Taxa10X,
  c.Taxa11X,
  c.Taxa12X
from Tc_Sge_Cartao c
order by c.Descricao
";

            var result = await connection.QueryAsync<CartaoCredito>(sql);

            return result;
        }

        public async Task<CartaoCredito> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  c.Id IdCartaoCredito,
  c.Descricao Bandeira,
  c.FormPagto1P FormatoPagamentoUmaParcela,
  c.FormPagto2a6P FormatoPagamentoDuasAteSeisParcelas,
  c.FormPagto7a12P FormatoPagamentoSeteAteDozeParcelas,
  c.Taxa01X,
  c.Taxa02X,
  c.Taxa03X,
  c.Taxa04X,
  c.Taxa05X,
  c.Taxa06X,
  c.Taxa07X,
  c.Taxa08X,
  c.Taxa09X,
  c.Taxa10X,
  c.Taxa11X,
  c.Taxa12X
from Tc_Sge_Cartao c
where c.Id = @IdCartaoCredito
order by c.Descricao
";

            var result = await connection.QueryFirstOrDefaultAsync<CartaoCredito>(sql, new
            {
                IdCartaoCredito = id
            });

            return result;
        }

        public Task<int> CreateAsync(CartaoCredito entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(CartaoCredito entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Cartao set
  Descricao = @Bandeira,
  FormPagto1P = @FormatoPagamentoUmaParcela,
  FormPagto2a6P = @FormatoPagamentoDuasAteSeisParcelas,
  FormPagto7a12P = @FormatoPagamentoSeteAteDozeParcelas,
  Taxa01X = @Taxa01X,
  Taxa02X = @Taxa02X,
  Taxa03X = @Taxa03X,
  Taxa04X = @Taxa04X,
  Taxa05X = @Taxa05X,
  Taxa06X = @Taxa06X,
  Taxa07X = @Taxa07X,
  Taxa08X = @Taxa08X,
  Taxa09X = @Taxa09X,
  Taxa10X = @Taxa10X,
  Taxa11X = @Taxa11X,
  Taxa12X = @Taxa12X
where Id = @IdCartaoCredito
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdCartaoCredito = entity.IdCartaoCredito,
                Bandeira = entity.Bandeira,
                FormatoPagamentoUmaParcela = entity.FormatoPagamentoUmaParcela,
                FormatoPagamentoDuasAteSeisParcelas = entity.FormatoPagamentoDuasAteSeisParcelas,
                FormatoPagamentoSeteAteDozeParcelas = entity.FormatoPagamentoSeteAteDozeParcelas,
                Taxa01X = entity.Taxa01X,
                Taxa02X = entity.Taxa02X,
                Taxa03X = entity.Taxa03X,
                Taxa04X = entity.Taxa04X,
                Taxa05X = entity.Taxa05X,
                Taxa06X = entity.Taxa06X,
                Taxa07X = entity.Taxa07X,
                Taxa08X = entity.Taxa08X,
                Taxa09X = entity.Taxa09X,
                Taxa10X = entity.Taxa10X,
                Taxa11X = entity.Taxa11X,
                Taxa12X = entity.Taxa12X
            });

            return result;
        }
    }
}
