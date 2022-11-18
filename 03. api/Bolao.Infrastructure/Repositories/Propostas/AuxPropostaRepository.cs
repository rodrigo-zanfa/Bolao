using Dapper;
using Bolao.Domain.Entities.Propostas;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.Propostas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.Propostas
{
    public class AuxPropostaRepository : IAuxPropostaRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public AuxPropostaRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public Task<IEnumerable<AuxProposta>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AuxProposta> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuxProposta> GetByGuidAsync(string guidProposta)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  ap.Id_Tabela,
  ap.Id_Proposta,
  ap.Id_Loja,
  ap.NomeProjeto,
  ap.Id_Estado,
  ap.Id_Cidade,
  ap.Id_Dimensionamento,
  ap.PotenciaKwh,
  ap.EnergiaMediaAnual,
  ap.ConsumoMensalJan,
  ap.ConsumoMensalFev,
  ap.ConsumoMensalMar,
  ap.ConsumoMensalAbr,
  ap.ConsumoMensalMai,
  ap.ConsumoMensalJun,
  ap.ConsumoMensalJul,
  ap.ConsumoMensalAgo,
  ap.ConsumoMensalSet,
  ap.ConsumoMensalOut,
  ap.ConsumoMensalNov,
  ap.ConsumoMensalDez,
  ap.Id_Fase,
  ap.Id_Tensao,
  ap.Id_Modulo,
  ap.Id_Orientacao_Telhado,
  ap.Id_Marca,
  ap.Id_Marca_Estrutura,
  ap.Id_Telhado,
  ap.PotenciaCalculada,
  ap.QtdModuloSugerido,
  ap.Porc_Projeto,
  ap.Porc_Instalacao,
  ap.IncluiMonitoramento,
  ap.Tipo_Frete,
  ap.Tipo_Proposta,
  ap.Valor_KWH,
  ap.ValorProjetoElsys,
  ap.ValorProjetoMargem,
  ap.Lg_Us_Inc,
  ap.Lg_Dt_Inc,
  ap.Lg_Us_Alt,
  ap.Lg_Dt_Alt,
  ap.Id_Usuario,
  ap.Valor_NF_Servico_Projeto,
  ap.Valor_NF_Servico_Instalacao,
  ap.Id_Tipo_Inversor,
  ap.HabilitaSeguro,
  ap.Id_CondicaoPagto,
  ap.ValorProjetoFinal,
  ap.Id_Unidade_Proposta,
  ap.Valor_Distribuidor_Bruto,
  ap.Valor_Distribuidor_Liquido,
  ap.GuidProposta,
  ap.PotenciaTotalCalculada
from Tc_Sge_Aux_Proposta ap
where ap.GuidProposta = @GuidProposta
order by ap.Id_Tabela
";

            var result = await connection.QueryFirstOrDefaultAsync<AuxProposta>(sql, new
            {
                GuidProposta = guidProposta
            });

            return result;
        }

        public async Task<(double porcentagemDistribuidor, double porcentagemLojista)> GetMargemDistribuidorLojistaAsync(int idLoja)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var parameters = new DynamicParameters();
            parameters.Add("@V_Id_Loja", idLoja);
            parameters.Add("@PorcentagemDistribuidor", dbType: DbType.Double, direction: ParameterDirection.Output);
            parameters.Add("@PorcentagemLojista", dbType: DbType.Double, direction: ParameterDirection.Output);

            await connection.ExecuteAsync("Sc_Sge_S_Margem_Distribuidor_Lojista", param: parameters, commandType: CommandType.StoredProcedure);

            var porcentagemDistribuidor = parameters.Get<double?>("@PorcentagemDistribuidor");
            var porcentagemLojista = parameters.Get<double?>("@PorcentagemLojista");

            return (porcentagemDistribuidor ?? 0, porcentagemLojista ?? 0);
        }

        public Task<int> CreateAsync(AuxProposta entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(AuxProposta entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Aux_Proposta set
  --Id_Tabela = @IdTabela,
  Id_Proposta = @IdProposta,
  Id_Loja = @IdLoja,
  NomeProjeto = @NomeProjeto,
  Id_Estado = @IdEstado,
  Id_Cidade = @IdCidade,
  Id_Dimensionamento = @IdDimensionamento,
  PotenciaKwh = @PotenciaKwh,
  EnergiaMediaAnual = @EnergiaMediaAnual,
  ConsumoMensalJan = @ConsumoMensalJan,
  ConsumoMensalFev = @ConsumoMensalFev,
  ConsumoMensalMar = @ConsumoMensalMar,
  ConsumoMensalAbr = @ConsumoMensalAbr,
  ConsumoMensalMai = @ConsumoMensalMai,
  ConsumoMensalJun = @ConsumoMensalJun,
  ConsumoMensalJul = @ConsumoMensalJul,
  ConsumoMensalAgo = @ConsumoMensalAgo,
  ConsumoMensalSet = @ConsumoMensalSet,
  ConsumoMensalOut = @ConsumoMensalOut,
  ConsumoMensalNov = @ConsumoMensalNov,
  ConsumoMensalDez = @ConsumoMensalDez,
  Id_Fase = @IdFase,
  Id_Tensao = @IdTensao,
  Id_Modulo = @IdModulo,
  Id_Orientacao_Telhado = @IdOrientacaoTelhado,
  Id_Marca = @IdMarca,
  Id_Marca_Estrutura = @IdMarcaEstrutura,
  Id_Telhado = @IdTelhado,
  PotenciaCalculada = @PotenciaCalculada,
  QtdModuloSugerido = @QtdModuloSugerido,
  Porc_Projeto = @PorcProjeto,
  Porc_Instalacao = @PorcInstalacao,
  IncluiMonitoramento = @IncluiMonitoramento,
  Tipo_Frete = @TipoFrete,
  Tipo_Proposta = @TipoProposta,
  Valor_KWH = @ValorKwh,
  ValorProjetoElsys = @ValorProjetoElsys,
  ValorProjetoMargem = @ValorProjetoMargem,
  --Lg_Us_Inc = @UsuarioInclusao,
  --Lg_Dt_Inc = @DataInclusao,
  Lg_Us_Alt = @UsuarioAlteracao,
  Lg_Dt_Alt = @DataAlteracao,
  Id_Usuario = @IdUsuario,
  Valor_NF_Servico_Projeto = @ValorNFServicoProjeto,
  Valor_NF_Servico_Instalacao = @ValorNFServicoInstalacao,
  Id_Tipo_Inversor = @IdTipoInversor,
  HabilitaSeguro = @HabilitaSeguro,
  Id_CondicaoPagto = @IdCondicaoPagto,
  ValorProjetoFinal = @ValorProjetoFinal,
  Id_Unidade_Proposta = @IdUnidadeProposta,
  --Valor_Distribuidor_Bruto = @ValorDistribuidorBruto,
  Valor_Distribuidor_Bruto = (
                              select sum(apg.QtdDesejada * apg.MargemDistribuidorValor)  --select sum(apg.Subtotal)
                              from Tc_Sge_Aux_Grid_Nova apg
                              where apg.GuidProposta = @GuidProposta
                             ),
  --Valor_Distribuidor_Liquido = @ValorDistribuidorLiquido,
  Valor_Distribuidor_Liquido = (
                                select top 1 apg.ValorRepasseLiquidoComissao
                                from Tc_Sge_Aux_Grid_Nova apg
                                where apg.GuidProposta = @GuidProposta
                               ),
  --GuidProposta = @GuidProposta,
  PotenciaTotalCalculada = isnull((
                                   select round(sum(apg.Quantidade * m.Potencia_Wp) / 1000, 2)
                                   from Tc_Sge_Aux_Grid_Nova apg
                                     inner join Tc_Sge_Modulo_Nova m on apg.Cod_Produto = m.Cod_Produto
                                   where apg.GuidProposta = @GuidProposta
                                  ), 0)
where GuidProposta = @GuidProposta
";

            var result = await connection.ExecuteAsync(sql, new
            {
                //IdTabela = entity.IdTabela,
                IdProposta = entity.IdProposta,
                IdLoja = entity.IdLoja,
                NomeProjeto = entity.NomeProjeto,
                IdEstado = entity.IdEstado,
                IdCidade = entity.IdCidade,
                IdDimensionamento = entity.IdDimensionamento,
                PotenciaKwh = entity.PotenciaKwh,
                EnergiaMediaAnual = entity.EnergiaMediaAnual,
                ConsumoMensalJan = entity.ConsumoMensalJan,
                ConsumoMensalFev = entity.ConsumoMensalFev,
                ConsumoMensalMar = entity.ConsumoMensalMar,
                ConsumoMensalAbr = entity.ConsumoMensalAbr,
                ConsumoMensalMai = entity.ConsumoMensalMai,
                ConsumoMensalJun = entity.ConsumoMensalJun,
                ConsumoMensalJul = entity.ConsumoMensalJul,
                ConsumoMensalAgo = entity.ConsumoMensalAgo,
                ConsumoMensalSet = entity.ConsumoMensalSet,
                ConsumoMensalOut = entity.ConsumoMensalOut,
                ConsumoMensalNov = entity.ConsumoMensalNov,
                ConsumoMensalDez = entity.ConsumoMensalDez,
                IdFase = entity.IdFase,
                IdTensao = entity.IdTensao,
                IdModulo = entity.IdModulo,
                IdOrientacaoTelhado = entity.IdOrientacaoTelhado,
                IdMarca = entity.IdMarca,
                IdMarcaEstrutura = entity.IdMarcaEstrutura,
                IdTelhado = entity.IdTelhado,
                PotenciaCalculada = entity.PotenciaCalculada,
                QtdModuloSugerido = entity.QtdModuloSugerido,
                PorcProjeto = entity.PorcProjeto,
                PorcInstalacao = entity.PorcInstalacao,
                IncluiMonitoramento = entity.IncluiMonitoramento,
                TipoFrete = entity.TipoFrete,
                TipoProposta = entity.TipoProposta,
                ValorKwh = entity.ValorKwh,
                ValorProjetoElsys = entity.ValorProjetoElsys,
                ValorProjetoMargem = entity.ValorProjetoMargem,
                //UsuarioInclusao = entity.UsuarioInclusao,
                //DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now,  // entity.DataAlteracao
                IdUsuario = entity.IdUsuario,
                ValorNFServicoProjeto = entity.ValorNFServicoProjeto,
                ValorNFServicoInstalacao = entity.ValorNFServicoInstalacao,
                IdTipoInversor = entity.IdTipoInversor,
                HabilitaSeguro = entity.HabilitaSeguro,
                IdCondicaoPagto = entity.IdCondicaoPagto,
                ValorProjetoFinal = entity.ValorProjetoFinal,
                IdUnidadeProposta = entity.IdUnidadeProposta,
                //ValorDistribuidorBruto = entity.ValorDistribuidorBruto,
                //ValorDistribuidorLiquido = entity.ValorDistribuidorLiquido,
                GuidProposta = entity.GuidProposta
            });

            return result;
        }
    }
}
