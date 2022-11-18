using Dapper;
using Bolao.Domain.Commands.Propostas;
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
    public class AuxPropostaGridRepository : IAuxPropostaGridRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public AuxPropostaGridRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public Task<IEnumerable<AuxPropostaGrid>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AuxPropostaGrid>> GetAllByGuidAsync(string guidProposta)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  apg.Id_Aux IdAux,
  apg.Id_Loja IdLoja,
  apg.Id_Usuario IdUsuario,
  apg.Descricao Descricao,
  apg.PrecoUnitario PrecoUnitario,
  apg.Quantidade Quantidade,
  apg.Subtotal Subtotal,
  apg.PrecoUnitarioComMargem PrecoUnitarioComMargem,
  apg.QtdDesejada QtdDesejada,
  apg.SubtotalComMargem SubtotalComMargem,
  apg.Potencia Potencia,
  apg.QtdModulo QtdModulo,
  apg.TotalSubtotal TotalSubtotal,
  apg.TotalSubtotalComMargem TotalSubtotalComMargem,
  apg.Porc_Desconto PorcDesconto,
  apg.PrecoUnitarioDesconto PrecoUnitarioDesconto,
  apg.Id_Tabela IdTabela,
  apg.Cod_Produto CodProduto,
  apg.Valor_NF_Servico_Projeto ValorNFServicoProjeto,
  apg.Valor_NF_Servico_Instalacao ValorNFServicoInstalacao,
  apg.ValorProjetoFinal ValorProjetoFinal,
  apg.DescricaoTipo DescricaoTipo,
  apg.Modelo Modelo,
  apg.Marca Marca,
  apg.Unidade Unidade,
  apg.GuidProposta GuidProposta,
  apg.PrecoUnitarioFixo PrecoUnitarioFixo,


  (
   select ap.PotenciaTotalCalculada
   from Tc_Sge_Aux_Proposta ap
   where ap.GuidProposta = @GuidProposta
  ) PotenciaTotalCalculada,
  (
   select ap.Id_CondicaoPagto
   from Tc_Sge_Aux_Proposta ap
   where ap.GuidProposta = @GuidProposta
  ) IdCondicaoPagto,


  apg.FretePorcentagem FretePorcentagem,
  apg.FreteValor FreteValor,
  apg.FreteValorSemCartao FreteValorSemCartao,

  apg.ImpostoPorcentagem ImpostoPorcentagem,
  apg.ImpostoValor ImpostoValor,
  apg.ImpostoValorSemCartao ImpostoValorSemCartao,

  apg.InadimplenciaPorcentagem InadimplenciaPorcentagem,
  apg.InadimplenciaValor InadimplenciaValor,
  apg.InadimplenciaValorSemCartao InadimplenciaValorSemCartao,

  apg.MarketingPorcentagem MarketingPorcentagem,
  apg.MarketingValor MarketingValor,
  apg.MarketingValorSemCartao MarketingValorSemCartao,

  apg.GarantiaPorcentagem GarantiaPorcentagem,
  apg.GarantiaValor GarantiaValor,
  apg.GarantiaValorSemCartao GarantiaValorSemCartao,

  apg.SeguroPorcentagem SeguroPorcentagem,
  apg.SeguroValor SeguroValor,
  apg.SeguroValorSemCartao SeguroValorSemCartao,

  apg.CartaoPorcentagem CartaoPorcentagem,
  apg.CartaoValor CartaoValor,

  apg.MargemElsysPorcentagem MargemElsysPorcentagem,
  apg.MargemElsysValor MargemElsysValor,
  apg.MargemElsysValorSemCartao MargemElsysValorSemCartao,

  apg.MargemDistribuidorPorcentagem MargemDistribuidorPorcentagem,
  apg.MargemDistribuidorValor MargemDistribuidorValor,
  apg.MargemDistribuidorValorSemCartao MargemDistribuidorValorSemCartao,

  apg.ValorUnitarioProduto ValorUnitarioProduto,
  apg.ValorUnitarioBaseCalculo ValorUnitarioBaseCalculo,
  apg.ValorUnitarioBaseCalculoSemCartao ValorUnitarioBaseCalculoSemCartao,

  apg.ValorBrutoServicos ValorBrutoServicos,
  apg.ValorRepasseLiquidoServicos ValorRepasseLiquidoServicos,
  apg.ValorAdicionalDevidoRepasseServicos ValorAdicionalDevidoRepasseServicos,
  apg.ValorAdicionalDevidoRepasseServicosSemCartao ValorAdicionalDevidoRepasseServicosSemCartao,

  apg.ValorRepasseLiquidoComissao ValorRepasseLiquidoComissao,
  apg.ValorRepasseLiquidoComissaoSemCartao ValorRepasseLiquidoComissaoSemCartao,
  apg.ValorAdicionalDevidoRepasseComissao ValorAdicionalDevidoRepasseComissao,
  apg.ValorAdicionalDevidoRepasseComissaoSemCartao ValorAdicionalDevidoRepasseComissaoSemCartao
from Tc_Sge_Aux_Grid_Nova apg
where apg.GuidProposta = @GuidProposta
  and apg.QtdDesejada > 0
order by apg.Id_Aux
";

            var result = await connection.QueryAsync<AuxPropostaGrid>(sql, new
            {
                GuidProposta = guidProposta
            });

            return result;
        }

        public async Task<AuxPropostaGrid> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  apg.Id_Aux IdAux,
  apg.Id_Loja IdLoja,
  apg.Id_Usuario IdUsuario,
  apg.Descricao Descricao,
  apg.PrecoUnitario PrecoUnitario,
  apg.Quantidade Quantidade,
  apg.Subtotal Subtotal,
  apg.PrecoUnitarioComMargem PrecoUnitarioComMargem,
  apg.QtdDesejada QtdDesejada,
  apg.SubtotalComMargem SubtotalComMargem,
  apg.Potencia Potencia,
  apg.QtdModulo QtdModulo,
  apg.TotalSubtotal TotalSubtotal,
  apg.TotalSubtotalComMargem TotalSubtotalComMargem,
  apg.Porc_Desconto PorcDesconto,
  apg.PrecoUnitarioDesconto PrecoUnitarioDesconto,
  apg.Id_Tabela IdTabela,
  apg.Cod_Produto CodProduto,
  apg.Valor_NF_Servico_Projeto ValorNFServicoProjeto,
  apg.Valor_NF_Servico_Instalacao ValorNFServicoInstalacao,
  apg.ValorProjetoFinal ValorProjetoFinal,
  apg.DescricaoTipo DescricaoTipo,
  apg.Modelo Modelo,
  apg.Marca Marca,
  apg.Unidade Unidade,
  apg.GuidProposta GuidProposta,
  apg.PrecoUnitarioFixo PrecoUnitarioFixo,


  (
   select ap.PotenciaTotalCalculada
   from Tc_Sge_Aux_Proposta ap
   where ap.GuidProposta = (
                            select apg.GuidProposta
                            from Tc_Sge_Aux_Grid_Nova apg
                            where apg.Id_Aux = @IdAux
                           )
  ) PotenciaTotalCalculada,
  (
   select ap.Id_CondicaoPagto
   from Tc_Sge_Aux_Proposta ap
   where ap.GuidProposta = (
                            select apg.GuidProposta
                            from Tc_Sge_Aux_Grid_Nova apg
                            where apg.Id_Aux = @IdAux
                           )
  ) IdCondicaoPagto,


  apg.FretePorcentagem FretePorcentagem,
  apg.FreteValor FreteValor,
  apg.FreteValorSemCartao FreteValorSemCartao,

  apg.ImpostoPorcentagem ImpostoPorcentagem,
  apg.ImpostoValor ImpostoValor,
  apg.ImpostoValorSemCartao ImpostoValorSemCartao,

  apg.InadimplenciaPorcentagem InadimplenciaPorcentagem,
  apg.InadimplenciaValor InadimplenciaValor,
  apg.InadimplenciaValorSemCartao InadimplenciaValorSemCartao,

  apg.MarketingPorcentagem MarketingPorcentagem,
  apg.MarketingValor MarketingValor,
  apg.MarketingValorSemCartao MarketingValorSemCartao,

  apg.GarantiaPorcentagem GarantiaPorcentagem,
  apg.GarantiaValor GarantiaValor,
  apg.GarantiaValorSemCartao GarantiaValorSemCartao,

  apg.SeguroPorcentagem SeguroPorcentagem,
  apg.SeguroValor SeguroValor,
  apg.SeguroValorSemCartao SeguroValorSemCartao,

  apg.CartaoPorcentagem CartaoPorcentagem,
  apg.CartaoValor CartaoValor,

  apg.MargemElsysPorcentagem MargemElsysPorcentagem,
  apg.MargemElsysValor MargemElsysValor,
  apg.MargemElsysValorSemCartao MargemElsysValorSemCartao,

  apg.MargemDistribuidorPorcentagem MargemDistribuidorPorcentagem,
  apg.MargemDistribuidorValor MargemDistribuidorValor,
  apg.MargemDistribuidorValorSemCartao MargemDistribuidorValorSemCartao,

  apg.ValorUnitarioProduto ValorUnitarioProduto,
  apg.ValorUnitarioBaseCalculo ValorUnitarioBaseCalculo,
  apg.ValorUnitarioBaseCalculoSemCartao ValorUnitarioBaseCalculoSemCartao,

  apg.ValorBrutoServicos ValorBrutoServicos,
  apg.ValorRepasseLiquidoServicos ValorRepasseLiquidoServicos,
  apg.ValorAdicionalDevidoRepasseServicos ValorAdicionalDevidoRepasseServicos,
  apg.ValorAdicionalDevidoRepasseServicosSemCartao ValorAdicionalDevidoRepasseServicosSemCartao,

  apg.ValorRepasseLiquidoComissao ValorRepasseLiquidoComissao,
  apg.ValorRepasseLiquidoComissaoSemCartao ValorRepasseLiquidoComissaoSemCartao,
  apg.ValorAdicionalDevidoRepasseComissao ValorAdicionalDevidoRepasseComissao,
  apg.ValorAdicionalDevidoRepasseComissaoSemCartao ValorAdicionalDevidoRepasseComissaoSemCartao
from Tc_Sge_Aux_Grid_Nova apg
where apg.Id_Aux = @IdAux
  and apg.QtdDesejada > 0
order by apg.Id_Aux
";

            var result = await connection.QueryFirstOrDefaultAsync<AuxPropostaGrid>(sql, new
            {
                IdAux = id
            });

            return result;
        }

        public async Task<AuxPropostaGrid> GetByCodigoAsync(string guidProposta, string codigo)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  apg.Id_Aux IdAux,
  apg.Id_Loja IdLoja,
  apg.Id_Usuario IdUsuario,
  apg.Descricao Descricao,
  apg.PrecoUnitario PrecoUnitario,
  apg.Quantidade Quantidade,
  apg.Subtotal Subtotal,
  apg.PrecoUnitarioComMargem PrecoUnitarioComMargem,
  apg.QtdDesejada QtdDesejada,
  apg.SubtotalComMargem SubtotalComMargem,
  apg.Potencia Potencia,
  apg.QtdModulo QtdModulo,
  apg.TotalSubtotal TotalSubtotal,
  apg.TotalSubtotalComMargem TotalSubtotalComMargem,
  apg.Porc_Desconto PorcDesconto,
  apg.PrecoUnitarioDesconto PrecoUnitarioDesconto,
  apg.Id_Tabela IdTabela,
  apg.Cod_Produto CodProduto,
  apg.Valor_NF_Servico_Projeto ValorNFServicoProjeto,
  apg.Valor_NF_Servico_Instalacao ValorNFServicoInstalacao,
  apg.ValorProjetoFinal ValorProjetoFinal,
  apg.DescricaoTipo DescricaoTipo,
  apg.Modelo Modelo,
  apg.Marca Marca,
  apg.Unidade Unidade,
  apg.GuidProposta GuidProposta,
  apg.PrecoUnitarioFixo PrecoUnitarioFixo,


  (
   select ap.PotenciaTotalCalculada
   from Tc_Sge_Aux_Proposta ap
   where ap.GuidProposta = @GuidProposta
  ) PotenciaTotalCalculada,
  (
   select ap.Id_CondicaoPagto
   from Tc_Sge_Aux_Proposta ap
   where ap.GuidProposta = @GuidProposta
  ) IdCondicaoPagto,


  apg.FretePorcentagem FretePorcentagem,
  apg.FreteValor FreteValor,
  apg.FreteValorSemCartao FreteValorSemCartao,

  apg.ImpostoPorcentagem ImpostoPorcentagem,
  apg.ImpostoValor ImpostoValor,
  apg.ImpostoValorSemCartao ImpostoValorSemCartao,

  apg.InadimplenciaPorcentagem InadimplenciaPorcentagem,
  apg.InadimplenciaValor InadimplenciaValor,
  apg.InadimplenciaValorSemCartao InadimplenciaValorSemCartao,

  apg.MarketingPorcentagem MarketingPorcentagem,
  apg.MarketingValor MarketingValor,
  apg.MarketingValorSemCartao MarketingValorSemCartao,

  apg.GarantiaPorcentagem GarantiaPorcentagem,
  apg.GarantiaValor GarantiaValor,
  apg.GarantiaValorSemCartao GarantiaValorSemCartao,

  apg.SeguroPorcentagem SeguroPorcentagem,
  apg.SeguroValor SeguroValor,
  apg.SeguroValorSemCartao SeguroValorSemCartao,

  apg.CartaoPorcentagem CartaoPorcentagem,
  apg.CartaoValor CartaoValor,

  apg.MargemElsysPorcentagem MargemElsysPorcentagem,
  apg.MargemElsysValor MargemElsysValor,
  apg.MargemElsysValorSemCartao MargemElsysValorSemCartao,

  apg.MargemDistribuidorPorcentagem MargemDistribuidorPorcentagem,
  apg.MargemDistribuidorValor MargemDistribuidorValor,
  apg.MargemDistribuidorValorSemCartao MargemDistribuidorValorSemCartao,

  apg.ValorUnitarioProduto ValorUnitarioProduto,
  apg.ValorUnitarioBaseCalculo ValorUnitarioBaseCalculo,
  apg.ValorUnitarioBaseCalculoSemCartao ValorUnitarioBaseCalculoSemCartao,

  apg.ValorBrutoServicos ValorBrutoServicos,
  apg.ValorRepasseLiquidoServicos ValorRepasseLiquidoServicos,
  apg.ValorAdicionalDevidoRepasseServicos ValorAdicionalDevidoRepasseServicos,
  apg.ValorAdicionalDevidoRepasseServicosSemCartao ValorAdicionalDevidoRepasseServicosSemCartao,

  apg.ValorRepasseLiquidoComissao ValorRepasseLiquidoComissao,
  apg.ValorRepasseLiquidoComissaoSemCartao ValorRepasseLiquidoComissaoSemCartao,
  apg.ValorAdicionalDevidoRepasseComissao ValorAdicionalDevidoRepasseComissao,
  apg.ValorAdicionalDevidoRepasseComissaoSemCartao ValorAdicionalDevidoRepasseComissaoSemCartao
from Tc_Sge_Aux_Grid_Nova apg
where apg.GuidProposta = @GuidProposta
  and apg.Cod_Produto = @CodProduto
  and apg.QtdDesejada > 0
order by apg.Id_Aux
";

            var result = await connection.QueryFirstOrDefaultAsync<AuxPropostaGrid>(sql, new
            {
                GuidProposta = guidProposta,
                CodProduto = codigo
            });

            return result;
        }

        public async Task<int> CreateAsync(AuxPropostaGrid entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Tc_Sge_Aux_Grid_Nova
(
  --Id_Aux,
  Id_Loja,
  Id_Usuario,
  Descricao,
  PrecoUnitario,
  Quantidade,
  Subtotal,
  PrecoUnitarioComMargem,
  QtdDesejada,
  SubtotalComMargem,
  Potencia,
  QtdModulo,
  TotalSubtotal,
  TotalSubtotalComMargem,
  Porc_Desconto,
  PrecoUnitarioDesconto,
  Id_Tabela,
  Cod_Produto,
  Valor_NF_Servico_Projeto,
  Valor_NF_Servico_Instalacao,
  ValorProjetoFinal,
  DescricaoTipo,
  Modelo,
  Marca,
  Unidade,
  GuidProposta,
  PrecoUnitarioFixo,

  FretePorcentagem,
  FreteValor,
  FreteValorSemCartao,

  ImpostoPorcentagem,
  ImpostoValor,
  ImpostoValorSemCartao,

  InadimplenciaPorcentagem,
  InadimplenciaValor,
  InadimplenciaValorSemCartao,

  MarketingPorcentagem,
  MarketingValor,
  MarketingValorSemCartao,

  GarantiaPorcentagem,
  GarantiaValor,
  GarantiaValorSemCartao,

  SeguroPorcentagem,
  SeguroValor,
  SeguroValorSemCartao,

  CartaoPorcentagem,
  CartaoValor,

  MargemElsysPorcentagem,
  MargemElsysValor,
  MargemElsysValorSemCartao,

  MargemDistribuidorPorcentagem,
  MargemDistribuidorValor,
  MargemDistribuidorValorSemCartao,

  ValorUnitarioProduto,
  ValorUnitarioBaseCalculo,
  ValorUnitarioBaseCalculoSemCartao,

  ValorBrutoServicos,
  ValorRepasseLiquidoServicos,
  ValorAdicionalDevidoRepasseServicos,
  ValorAdicionalDevidoRepasseServicosSemCartao,

  ValorRepasseLiquidoComissao,
  ValorRepasseLiquidoComissaoSemCartao,
  ValorAdicionalDevidoRepasseComissao,
  ValorAdicionalDevidoRepasseComissaoSemCartao
)
values
(
  --@IdAux,
  @IdLoja,
  @IdUsuario,
  @Descricao,
  @PrecoUnitario,
  @Quantidade,
  @Subtotal,
  @PrecoUnitarioComMargem,
  @QtdDesejada,
  @SubtotalComMargem,
  @Potencia,
  @QtdModulo,
  @TotalSubtotal,
  @TotalSubtotalComMargem,
  @PorcDesconto,
  @PrecoUnitarioDesconto,
  @IdTabela,
  @CodProduto,
  @ValorNFServicoProjeto,
  @ValorNFServicoInstalacao,
  @ValorProjetoFinal,
  @DescricaoTipo,
  @Modelo,
  @Marca,
  @Unidade,
  @GuidProposta,
  @PrecoUnitarioFixo,

  @FretePorcentagem,
  @FreteValor,
  @FreteValorSemCartao,

  @ImpostoPorcentagem,
  @ImpostoValor,
  @ImpostoValorSemCartao,

  @InadimplenciaPorcentagem,
  @InadimplenciaValor,
  @InadimplenciaValorSemCartao,

  @MarketingPorcentagem,
  @MarketingValor,
  @MarketingValorSemCartao,

  @GarantiaPorcentagem,
  @GarantiaValor,
  @GarantiaValorSemCartao,

  @SeguroPorcentagem,
  @SeguroValor,
  @SeguroValorSemCartao,

  @CartaoPorcentagem,
  @CartaoValor,

  @MargemElsysPorcentagem,
  @MargemElsysValor,
  @MargemElsysValorSemCartao,

  @MargemDistribuidorPorcentagem,
  @MargemDistribuidorValor,
  @MargemDistribuidorValorSemCartao,

  @ValorUnitarioProduto,
  @ValorUnitarioBaseCalculo,
  @ValorUnitarioBaseCalculoSemCartao,

  @ValorBrutoServicos,
  @ValorRepasseLiquidoServicos,
  @ValorAdicionalDevidoRepasseServicos,
  @ValorAdicionalDevidoRepasseServicosSemCartao,

  @ValorRepasseLiquidoComissao,
  @ValorRepasseLiquidoComissaoSemCartao,
  @ValorAdicionalDevidoRepasseComissao,
  @ValorAdicionalDevidoRepasseComissaoSemCartao
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdAux = entity.IdAux,
                IdLoja = entity.IdLoja,
                IdUsuario = entity.IdUsuario,
                Descricao = entity.Descricao,
                PrecoUnitario = entity.PrecoUnitario,
                Quantidade = entity.Quantidade,
                Subtotal = entity.Subtotal,
                PrecoUnitarioComMargem = entity.PrecoUnitarioComMargem,
                QtdDesejada = entity.QtdDesejada,
                SubtotalComMargem = entity.SubtotalComMargem,
                Potencia = entity.Potencia,
                QtdModulo = entity.QtdModulo,
                TotalSubtotal = entity.TotalSubtotal,
                TotalSubtotalComMargem = entity.TotalSubtotalComMargem,
                PorcDesconto = entity.PorcDesconto,
                PrecoUnitarioDesconto = entity.PrecoUnitarioDesconto,
                IdTabela = entity.IdTabela,
                CodProduto = entity.CodProduto,
                ValorNFServicoProjeto = entity.ValorNFServicoProjeto,
                ValorNFServicoInstalacao = entity.ValorNFServicoInstalacao,
                ValorProjetoFinal = entity.ValorProjetoFinal,
                DescricaoTipo = entity.DescricaoTipo,
                Modelo = entity.Modelo,
                Marca = entity.Marca,
                Unidade = entity.Unidade,
                GuidProposta = entity.GuidProposta,
                PrecoUnitarioFixo = entity.PrecoUnitarioFixo,
                FretePorcentagem = entity.FretePorcentagem,
                FreteValor = entity.FreteValor,
                FreteValorSemCartao = entity.FreteValorSemCartao,
                ImpostoPorcentagem = entity.ImpostoPorcentagem,
                ImpostoValor = entity.ImpostoValor,
                ImpostoValorSemCartao = entity.ImpostoValorSemCartao,
                InadimplenciaPorcentagem = entity.InadimplenciaPorcentagem,
                InadimplenciaValor = entity.InadimplenciaValor,
                InadimplenciaValorSemCartao = entity.InadimplenciaValorSemCartao,
                MarketingPorcentagem = entity.MarketingPorcentagem,
                MarketingValor = entity.MarketingValor,
                MarketingValorSemCartao = entity.MarketingValorSemCartao,
                GarantiaPorcentagem = entity.GarantiaPorcentagem,
                GarantiaValor = entity.GarantiaValor,
                GarantiaValorSemCartao = entity.GarantiaValorSemCartao,
                SeguroPorcentagem = entity.SeguroPorcentagem,
                SeguroValor = entity.SeguroValor,
                SeguroValorSemCartao = entity.SeguroValorSemCartao,
                CartaoPorcentagem = entity.CartaoPorcentagem,
                CartaoValor = entity.CartaoValor,
                MargemElsysPorcentagem = entity.MargemElsysPorcentagem,
                MargemElsysValor = entity.MargemElsysValor,
                MargemElsysValorSemCartao = entity.MargemElsysValorSemCartao,
                MargemDistribuidorPorcentagem = entity.MargemDistribuidorPorcentagem,
                MargemDistribuidorValor = entity.MargemDistribuidorValor,
                MargemDistribuidorValorSemCartao = entity.MargemDistribuidorValorSemCartao,
                ValorUnitarioProduto = entity.ValorUnitarioProduto,
                ValorUnitarioBaseCalculo = entity.ValorUnitarioBaseCalculo,
                ValorUnitarioBaseCalculoSemCartao = entity.ValorUnitarioBaseCalculoSemCartao,
                ValorBrutoServicos = entity.ValorBrutoServicos,
                ValorRepasseLiquidoServicos = entity.ValorRepasseLiquidoServicos,
                ValorAdicionalDevidoRepasseServicos = entity.ValorAdicionalDevidoRepasseServicos,
                ValorAdicionalDevidoRepasseServicosSemCartao = entity.ValorAdicionalDevidoRepasseServicosSemCartao,
                ValorRepasseLiquidoComissao = entity.ValorRepasseLiquidoComissao,
                ValorRepasseLiquidoComissaoSemCartao = entity.ValorRepasseLiquidoComissaoSemCartao,
                ValorAdicionalDevidoRepasseComissao = entity.ValorAdicionalDevidoRepasseComissao,
                ValorAdicionalDevidoRepasseComissaoSemCartao = entity.ValorAdicionalDevidoRepasseComissaoSemCartao
            });

            return result;
        }

        public async Task<IEnumerable<AuxPropostaGrid>> CalcularItensAsync(CalcularItensCommand command)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
exec Sc_Sge_M_Calculo_Planilha_Nova
    @V_Id_Loja = @IdLoja,
    @V_NomeProjeto = @NomeProjeto,
    @V_Id_Estado = @IdEstado,
    @V_Id_Cidade = @IdCidade,
    @V_Id_Dimensionamento = @IdDimensionamento,
    @V_PotenciaKwh = @PotenciaKwh,
    @V_PotenciaCalculada = @PotenciaCalculada,
    @V_Energia_Media = @EnergiaMedia,
    @V_ConsumoMensalJan = @ConsumoMensalJan,
    @V_ConsumoMensalFev = @ConsumoMensalFev,
    @V_ConsumoMensalMar = @ConsumoMensalMar,
    @V_ConsumoMensalAbr = @ConsumoMensalAbr,
    @V_ConsumoMensalMai = @ConsumoMensalMai,
    @V_ConsumoMensalJun = @ConsumoMensalJun,
    @V_ConsumoMensalJul = @ConsumoMensalJul,
    @V_ConsumoMensalAgo = @ConsumoMensalAgo,
    @V_ConsumoMensalSet = @ConsumoMensalSet,
    @V_ConsumoMensalOut = @ConsumoMensalOut,
    @V_ConsumoMensalNov = @ConsumoMensalNov,
    @V_ConsumoMensalDez = @ConsumoMensalDez,
    @V_Id_Fase = @IdFase,
    @V_Id_Tensao = @IdTensao,
    @V_Id_Modulo = @IdModulo,
    @V_Id_Marca = @IdMarca,
    @V_Id_Marca_Estrutura = @IdMarcaEstrutura,
    @V_IncluiMonitoramento = @IncluiMonitoramento,
    @V_TipoFrete = @TipoFrete,
    @V_Usuario = @IdUsuario,
    @V_Qtd_Modulo = @QtdModulo,
    @V_Id_Tipo_Inversor = @IdTipoInversor,
    @V_HabilitaSeguro = @HabilitaSeguro,
    @V_TipoCondicaoPagto = @TipoCondicaoPagto,
    @V_PropostaGuid = @GuidProposta,
    @V_RealizarCalculosViaAPI = @RealizarCalculosViaAPI
";

            var result = await connection.QueryAsync<AuxPropostaGrid>(sql, new
            {
                IdLoja = command.IdLoja,
                NomeProjeto = command.NomeProjeto,
                IdEstado = command.IdEstado,
                IdCidade = command.IdCidade,
                IdDimensionamento = command.IdDimensionamento,
                PotenciaKwh = command.PotenciaKwh,
                PotenciaCalculada = command.PotenciaCalculada,
                EnergiaMedia = command.EnergiaMedia,
                ConsumoMensalJan = command.ConsumoMensalJan,
                ConsumoMensalFev = command.ConsumoMensalFev,
                ConsumoMensalMar = command.ConsumoMensalMar,
                ConsumoMensalAbr = command.ConsumoMensalAbr,
                ConsumoMensalMai = command.ConsumoMensalMai,
                ConsumoMensalJun = command.ConsumoMensalJun,
                ConsumoMensalJul = command.ConsumoMensalJul,
                ConsumoMensalAgo = command.ConsumoMensalAgo,
                ConsumoMensalSet = command.ConsumoMensalSet,
                ConsumoMensalOut = command.ConsumoMensalOut,
                ConsumoMensalNov = command.ConsumoMensalNov,
                ConsumoMensalDez = command.ConsumoMensalDez,
                IdFase = command.IdFase,
                IdTensao = command.IdTensao,
                IdModulo = command.IdModulo,
                IdMarca = command.IdMarca,
                IdMarcaEstrutura = command.IdMarcaEstrutura,
                IncluiMonitoramento = command.IncluiMonitoramento,
                TipoFrete = command.TipoFrete,
                IdUsuario = command.IdUsuario,
                QtdModulo = command.QtdModulo,
                IdTipoInversor = command.IdTipoInversor,
                HabilitaSeguro = command.HabilitaSeguro,
                TipoCondicaoPagto = command.TipoCondicaoPagto,
                GuidProposta = command.GuidProposta,
                RealizarCalculosViaAPI = command.RealizarCalculosViaAPI
            });

            return result;
        }

        public async Task<int> UpdateAsync(AuxPropostaGrid entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Aux_Grid_Nova set
  Id_Loja = @IdLoja,
  Id_Usuario = @IdUsuario,
  Descricao = @Descricao,
  PrecoUnitario = @PrecoUnitario,
  Quantidade = @Quantidade,
  Subtotal = @Subtotal,
  PrecoUnitarioComMargem = @PrecoUnitarioComMargem,
  QtdDesejada = @QtdDesejada,
  SubtotalComMargem = @SubtotalComMargem,
  Potencia = @Potencia,
  QtdModulo = @QtdModulo,
  TotalSubtotal = @TotalSubtotal,
  TotalSubtotalComMargem = @TotalSubtotalComMargem,
  Porc_Desconto = @PorcDesconto,
  PrecoUnitarioDesconto = @PrecoUnitarioDesconto,
  Id_Tabela = @IdTabela,
  Cod_Produto = @CodProduto,
  Valor_NF_Servico_Projeto = @ValorNFServicoProjeto,
  Valor_NF_Servico_Instalacao = @ValorNFServicoInstalacao,
  ValorProjetoFinal = @ValorProjetoFinal,
  DescricaoTipo = @DescricaoTipo,
  Modelo = @Modelo,
  Marca = @Marca,
  Unidade = @Unidade,
  GuidProposta = @GuidProposta,
  PrecoUnitarioFixo = @PrecoUnitarioFixo,

  FretePorcentagem = @FretePorcentagem,
  FreteValor = @FreteValor,
  FreteValorSemCartao = @FreteValorSemCartao,

  ImpostoPorcentagem = @ImpostoPorcentagem,
  ImpostoValor = @ImpostoValor,
  ImpostoValorSemCartao = @ImpostoValorSemCartao,

  InadimplenciaPorcentagem = @InadimplenciaPorcentagem,
  InadimplenciaValor = @InadimplenciaValor,
  InadimplenciaValorSemCartao = @InadimplenciaValorSemCartao,

  MarketingPorcentagem = @MarketingPorcentagem,
  MarketingValor = @MarketingValor,
  MarketingValorSemCartao = @MarketingValorSemCartao,

  GarantiaPorcentagem = @GarantiaPorcentagem,
  GarantiaValor = @GarantiaValor,
  GarantiaValorSemCartao = @GarantiaValorSemCartao,

  SeguroPorcentagem = @SeguroPorcentagem,
  SeguroValor = @SeguroValor,
  SeguroValorSemCartao = @SeguroValorSemCartao,

  CartaoPorcentagem = @CartaoPorcentagem,
  CartaoValor = @CartaoValor,

  MargemElsysPorcentagem = @MargemElsysPorcentagem,
  MargemElsysValor = @MargemElsysValor,
  MargemElsysValorSemCartao = @MargemElsysValorSemCartao,

  MargemDistribuidorPorcentagem = @MargemDistribuidorPorcentagem,
  MargemDistribuidorValor = @MargemDistribuidorValor,
  MargemDistribuidorValorSemCartao = @MargemDistribuidorValorSemCartao,

  ValorUnitarioProduto = @ValorUnitarioProduto,
  ValorUnitarioBaseCalculo = @ValorUnitarioBaseCalculo,
  ValorUnitarioBaseCalculoSemCartao = @ValorUnitarioBaseCalculoSemCartao,

  ValorBrutoServicos = @ValorBrutoServicos,
  ValorRepasseLiquidoServicos = @ValorRepasseLiquidoServicos,
  ValorAdicionalDevidoRepasseServicos = @ValorAdicionalDevidoRepasseServicos,
  ValorAdicionalDevidoRepasseServicosSemCartao = @ValorAdicionalDevidoRepasseServicosSemCartao,

  ValorRepasseLiquidoComissao = @ValorRepasseLiquidoComissao,
  ValorRepasseLiquidoComissaoSemCartao = @ValorRepasseLiquidoComissaoSemCartao,
  ValorAdicionalDevidoRepasseComissao = @ValorAdicionalDevidoRepasseComissao,
  ValorAdicionalDevidoRepasseComissaoSemCartao = @ValorAdicionalDevidoRepasseComissaoSemCartao
where Id_Aux = @IdAux
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdAux = entity.IdAux,
                IdLoja = entity.IdLoja,
                IdUsuario = entity.IdUsuario,
                Descricao = entity.Descricao,
                PrecoUnitario = entity.PrecoUnitario,
                Quantidade = entity.Quantidade,
                Subtotal = entity.Subtotal,
                PrecoUnitarioComMargem = entity.PrecoUnitarioComMargem,
                QtdDesejada = entity.QtdDesejada,
                SubtotalComMargem = entity.SubtotalComMargem,
                Potencia = entity.Potencia,
                QtdModulo = entity.QtdModulo,
                TotalSubtotal = entity.TotalSubtotal,
                TotalSubtotalComMargem = entity.TotalSubtotalComMargem,
                PorcDesconto = entity.PorcDesconto,
                PrecoUnitarioDesconto = entity.PrecoUnitarioDesconto,
                IdTabela = entity.IdTabela,
                CodProduto = entity.CodProduto,
                ValorNFServicoProjeto = entity.ValorNFServicoProjeto,
                ValorNFServicoInstalacao = entity.ValorNFServicoInstalacao,
                ValorProjetoFinal = entity.ValorProjetoFinal,
                DescricaoTipo = entity.DescricaoTipo,
                Modelo = entity.Modelo,
                Marca = entity.Marca,
                Unidade = entity.Unidade,
                GuidProposta = entity.GuidProposta,
                PrecoUnitarioFixo = entity.PrecoUnitarioFixo,
                FretePorcentagem = entity.FretePorcentagem,
                FreteValor = entity.FreteValor,
                FreteValorSemCartao = entity.FreteValorSemCartao,
                ImpostoPorcentagem = entity.ImpostoPorcentagem,
                ImpostoValor = entity.ImpostoValor,
                ImpostoValorSemCartao = entity.ImpostoValorSemCartao,
                InadimplenciaPorcentagem = entity.InadimplenciaPorcentagem,
                InadimplenciaValor = entity.InadimplenciaValor,
                InadimplenciaValorSemCartao = entity.InadimplenciaValorSemCartao,
                MarketingPorcentagem = entity.MarketingPorcentagem,
                MarketingValor = entity.MarketingValor,
                MarketingValorSemCartao = entity.MarketingValorSemCartao,
                GarantiaPorcentagem = entity.GarantiaPorcentagem,
                GarantiaValor = entity.GarantiaValor,
                GarantiaValorSemCartao = entity.GarantiaValorSemCartao,
                SeguroPorcentagem = entity.SeguroPorcentagem,
                SeguroValor = entity.SeguroValor,
                SeguroValorSemCartao = entity.SeguroValorSemCartao,
                CartaoPorcentagem = entity.CartaoPorcentagem,
                CartaoValor = entity.CartaoValor,
                MargemElsysPorcentagem = entity.MargemElsysPorcentagem,
                MargemElsysValor = entity.MargemElsysValor,
                MargemElsysValorSemCartao = entity.MargemElsysValorSemCartao,
                MargemDistribuidorPorcentagem = entity.MargemDistribuidorPorcentagem,
                MargemDistribuidorValor = entity.MargemDistribuidorValor,
                MargemDistribuidorValorSemCartao = entity.MargemDistribuidorValorSemCartao,
                ValorUnitarioProduto = entity.ValorUnitarioProduto,
                ValorUnitarioBaseCalculo = entity.ValorUnitarioBaseCalculo,
                ValorUnitarioBaseCalculoSemCartao = entity.ValorUnitarioBaseCalculoSemCartao,
                ValorBrutoServicos = entity.ValorBrutoServicos,
                ValorRepasseLiquidoServicos = entity.ValorRepasseLiquidoServicos,
                ValorAdicionalDevidoRepasseServicos = entity.ValorAdicionalDevidoRepasseServicos,
                ValorAdicionalDevidoRepasseServicosSemCartao = entity.ValorAdicionalDevidoRepasseServicosSemCartao,
                ValorRepasseLiquidoComissao = entity.ValorRepasseLiquidoComissao,
                ValorRepasseLiquidoComissaoSemCartao = entity.ValorRepasseLiquidoComissaoSemCartao,
                ValorAdicionalDevidoRepasseComissao = entity.ValorAdicionalDevidoRepasseComissao,
                ValorAdicionalDevidoRepasseComissaoSemCartao = entity.ValorAdicionalDevidoRepasseComissaoSemCartao
            });

            return result;
        }

        public async Task<int> UpdateValoresCalculadosAsync(AuxPropostaGrid entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Aux_Grid_Nova set
  FretePorcentagem = @FretePorcentagem,
  FreteValor = @FreteValor,
  FreteValorSemCartao = @FreteValorSemCartao,

  ImpostoPorcentagem = @ImpostoPorcentagem,
  ImpostoValor = @ImpostoValor,
  ImpostoValorSemCartao = @ImpostoValorSemCartao,

  InadimplenciaPorcentagem = @InadimplenciaPorcentagem,
  InadimplenciaValor = @InadimplenciaValor,
  InadimplenciaValorSemCartao = @InadimplenciaValorSemCartao,

  MarketingPorcentagem = @MarketingPorcentagem,
  MarketingValor = @MarketingValor,
  MarketingValorSemCartao = @MarketingValorSemCartao,

  GarantiaPorcentagem = @GarantiaPorcentagem,
  GarantiaValor = @GarantiaValor,
  GarantiaValorSemCartao = @GarantiaValorSemCartao,

  SeguroPorcentagem = @SeguroPorcentagem,
  SeguroValor = @SeguroValor,
  SeguroValorSemCartao = @SeguroValorSemCartao,

  CartaoPorcentagem = @CartaoPorcentagem,
  CartaoValor = @CartaoValor,

  MargemElsysPorcentagem = @MargemElsysPorcentagem,
  MargemElsysValor = @MargemElsysValor,
  MargemElsysValorSemCartao = @MargemElsysValorSemCartao,

  MargemDistribuidorPorcentagem = @MargemDistribuidorPorcentagem,
  MargemDistribuidorValor = @MargemDistribuidorValor,
  MargemDistribuidorValorSemCartao = @MargemDistribuidorValorSemCartao,

  ValorUnitarioProduto = @ValorUnitarioProduto,
  ValorUnitarioBaseCalculo = @ValorUnitarioBaseCalculo,
  ValorUnitarioBaseCalculoSemCartao = @ValorUnitarioBaseCalculoSemCartao,

  PrecoUnitario = @ValorUnitarioBaseCalculo,
  --PrecoUnitarioFixo = ,
  --Subtotal = QtdDesejada * @ValorUnitarioBaseCalculoSemCartao,  /* somente equipamento, valor à vista */
  PrecoUnitarioComMargem = @ValorUnitarioBaseCalculo,
  PrecoUnitarioDesconto = @ValorUnitarioBaseCalculo--,
  --SubtotalComMargem = QtdDesejada * @ValorUnitarioBaseCalculoSemCartao,  /* equipamento + serviços, valor à vista */
  --Valor_NF_Servico_Projeto = ,
  --Valor_NF_Servico_Instalacao = ,
where Id_Aux = @IdAux
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdAux = entity.IdAux,
                FretePorcentagem = entity.FretePorcentagem,
                FreteValor = entity.FreteValor,
                FreteValorSemCartao = entity.FreteValorSemCartao,
                ImpostoPorcentagem = entity.ImpostoPorcentagem,
                ImpostoValor = entity.ImpostoValor,
                ImpostoValorSemCartao = entity.ImpostoValorSemCartao,
                InadimplenciaPorcentagem = entity.InadimplenciaPorcentagem,
                InadimplenciaValor = entity.InadimplenciaValor,
                InadimplenciaValorSemCartao = entity.InadimplenciaValorSemCartao,
                MarketingPorcentagem = entity.MarketingPorcentagem,
                MarketingValor = entity.MarketingValor,
                MarketingValorSemCartao = entity.MarketingValorSemCartao,
                GarantiaPorcentagem = entity.GarantiaPorcentagem,
                GarantiaValor = entity.GarantiaValor,
                GarantiaValorSemCartao = entity.GarantiaValorSemCartao,
                SeguroPorcentagem = entity.SeguroPorcentagem,
                SeguroValor = entity.SeguroValor,
                SeguroValorSemCartao = entity.SeguroValorSemCartao,
                CartaoPorcentagem = entity.CartaoPorcentagem,
                CartaoValor = entity.CartaoValor,
                MargemElsysPorcentagem = entity.MargemElsysPorcentagem,
                MargemElsysValor = entity.MargemElsysValor,
                MargemElsysValorSemCartao = entity.MargemElsysValorSemCartao,
                MargemDistribuidorPorcentagem = entity.MargemDistribuidorPorcentagem,
                MargemDistribuidorValor = entity.MargemDistribuidorValor,
                MargemDistribuidorValorSemCartao = entity.MargemDistribuidorValorSemCartao,
                ValorUnitarioProduto = entity.ValorUnitarioProduto,
                ValorUnitarioBaseCalculo = entity.ValorUnitarioBaseCalculo,
                ValorUnitarioBaseCalculoSemCartao = entity.ValorUnitarioBaseCalculoSemCartao
            });

            return result;
        }

        public async Task<int> UpdateValoresCalculadosTotaisAsync(string guidProposta, double valorNFServicoProjeto, double valorNFServicoInstalacao, double valorBrutoServicos, double valorRepasseLiquidoServicos, double valorAdicionalDevidoRepasseServicos,
            double valorRepasseLiquidoComissao, double valorAdicionalDevidoRepasseComissao, double valorAdicionalDevidoRepasseServicosSemCartao, double valorRepasseLiquidoComissaoSemCartao, double valorAdicionalDevidoRepasseComissaoSemCartao)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Aux_Grid_Nova set
  Valor_NF_Servico_Projeto = @ValorNFServicoProjeto,
  Valor_NF_Servico_Instalacao = @ValorNFServicoInstalacao,

  ValorBrutoServicos = @ValorBrutoServicos,
  ValorRepasseLiquidoServicos = @ValorRepasseLiquidoServicos,
  ValorAdicionalDevidoRepasseServicos = @ValorAdicionalDevidoRepasseServicos,
  ValorAdicionalDevidoRepasseServicosSemCartao = @ValorAdicionalDevidoRepasseServicosSemCartao,

  ValorRepasseLiquidoComissao = @ValorRepasseLiquidoComissao,
  ValorRepasseLiquidoComissaoSemCartao = @ValorRepasseLiquidoComissaoSemCartao,
  ValorAdicionalDevidoRepasseComissao = @ValorAdicionalDevidoRepasseComissao,
  ValorAdicionalDevidoRepasseComissaoSemCartao = @ValorAdicionalDevidoRepasseComissaoSemCartao,

  /* será sempre a soma de todas as linhas dentro da proposta, portanto os valores serão repetidos */
  TotalSubtotal = (  /* somente equipamento, valor à vista */
                   select sum(apg.QtdDesejada * (case apg.ValorUnitarioBaseCalculoSemCartao when 0 then apg.ValorUnitarioBaseCalculo else apg.ValorUnitarioBaseCalculoSemCartao end))  --select sum(apg.Subtotal)
                   from Tc_Sge_Aux_Grid_Nova apg
                   where apg.GuidProposta = @GuidProposta
                  ) + @ValorAdicionalDevidoRepasseComissaoSemCartao,

  /* será sempre a soma de todas as linhas dentro da proposta, portanto os valores serão repetidos */
  TotalSubtotalComMargem = (  /* equipamento + serviços, valor à vista */
                            select sum(apg.QtdDesejada * (case apg.ValorUnitarioBaseCalculoSemCartao when 0 then apg.ValorUnitarioBaseCalculo else apg.ValorUnitarioBaseCalculoSemCartao end))  --select sum(apg.SubtotalComMargem)
                            from Tc_Sge_Aux_Grid_Nova apg
                            where apg.GuidProposta = @GuidProposta
                           ) + @ValorAdicionalDevidoRepasseServicosSemCartao + @ValorAdicionalDevidoRepasseComissaoSemCartao,

  /* será sempre a soma de todas as linhas dentro da proposta, portanto os valores serão repetidos */
  ValorProjetoFinal = (
                       select sum(apg.QtdDesejada * apg.ValorUnitarioBaseCalculo)  --select sum(apg.SubtotalComMargem)
                       from Tc_Sge_Aux_Grid_Nova apg
                       where apg.GuidProposta = @GuidProposta
                      ) + @ValorAdicionalDevidoRepasseServicos + @ValorAdicionalDevidoRepasseComissao
where GuidProposta = @GuidProposta
  and QtdDesejada > 0
";

            var result = await connection.ExecuteAsync(sql, new
            {
                GuidProposta = guidProposta,
                ValorNFServicoProjeto = valorNFServicoProjeto,
                ValorNFServicoInstalacao = valorNFServicoInstalacao,
                ValorBrutoServicos = valorBrutoServicos,
                ValorRepasseLiquidoServicos = valorRepasseLiquidoServicos,
                ValorAdicionalDevidoRepasseServicos = valorAdicionalDevidoRepasseServicos,
                ValorAdicionalDevidoRepasseServicosSemCartao = valorAdicionalDevidoRepasseServicosSemCartao,
                ValorRepasseLiquidoComissao = valorRepasseLiquidoComissao,
                ValorRepasseLiquidoComissaoSemCartao = valorRepasseLiquidoComissaoSemCartao,
                ValorAdicionalDevidoRepasseComissao = valorAdicionalDevidoRepasseComissao,
                ValorAdicionalDevidoRepasseComissaoSemCartao = valorAdicionalDevidoRepasseComissaoSemCartao
            });

            return result;
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
delete from Tc_Sge_Aux_Grid_Nova
where Id_Aux = @IdAux
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdAux = id
            });

            return result;
        }
    }
}
