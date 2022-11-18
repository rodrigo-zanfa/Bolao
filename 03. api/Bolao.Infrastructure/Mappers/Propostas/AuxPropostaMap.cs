using Dapper.FluentMap.Mapping;
using Bolao.Domain.Entities.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Mappers.Propostas
{
    public class AuxPropostaMap : EntityMap<AuxProposta>
    {
        public AuxPropostaMap()
        {
            Map(p => p.IdTabela)
                .ToColumn("Id_Tabela", false);

            Map(p => p.IdProposta)
                .ToColumn("Id_Proposta", false);

            Map(p => p.IdLoja)
                .ToColumn("Id_Loja", false);

            //Map(p => p.NomeProjeto)
            //    .ToColumn("NomeProjeto", false);

            Map(p => p.IdEstado)
                .ToColumn("Id_Estado", false);

            Map(p => p.IdCidade)
                .ToColumn("Id_Cidade", false);

            Map(p => p.IdDimensionamento)
                .ToColumn("Id_Dimensionamento", false);

            //Map(p => p.PotenciaKwh)
            //    .ToColumn("PotenciaKwh", false);

            //Map(p => p.EnergiaMediaAnual)
            //    .ToColumn("EnergiaMediaAnual", false);

            //Map(p => p.ConsumoMensalJan)
            //    .ToColumn("ConsumoMensalJan", false);

            //Map(p => p.ConsumoMensalFev)
            //    .ToColumn("ConsumoMensalFev", false);

            //Map(p => p.ConsumoMensalMar)
            //    .ToColumn("ConsumoMensalMar", false);

            //Map(p => p.ConsumoMensalAbr)
            //    .ToColumn("ConsumoMensalAbr", false);

            //Map(p => p.ConsumoMensalMai)
            //    .ToColumn("ConsumoMensalMai", false);

            //Map(p => p.ConsumoMensalJun)
            //    .ToColumn("ConsumoMensalJun", false);

            //Map(p => p.ConsumoMensalJul)
            //    .ToColumn("ConsumoMensalJul", false);

            //Map(p => p.ConsumoMensalAgo)
            //    .ToColumn("ConsumoMensalAgo", false);

            //Map(p => p.ConsumoMensalSet)
            //    .ToColumn("ConsumoMensalSet", false);

            //Map(p => p.ConsumoMensalOut)
            //    .ToColumn("ConsumoMensalOut", false);

            //Map(p => p.ConsumoMensalNov)
            //    .ToColumn("ConsumoMensalNov", false);

            //Map(p => p.ConsumoMensalDez)
            //    .ToColumn("ConsumoMensalDez", false);

            Map(p => p.IdFase)
                .ToColumn("Id_Fase", false);

            Map(p => p.IdTensao)
                .ToColumn("Id_Tensao", false);

            Map(p => p.IdModulo)
                .ToColumn("Id_Modulo", false);

            Map(p => p.IdOrientacaoTelhado)
                .ToColumn("Id_Orientacao_Telhado", false);

            Map(p => p.IdMarca)
                .ToColumn("Id_Marca", false);

            Map(p => p.IdMarcaEstrutura)
                .ToColumn("Id_Marca_Estrutura", false);

            Map(p => p.IdTelhado)
                .ToColumn("Id_Telhado", false);

            //Map(p => p.PotenciaCalculada)
            //    .ToColumn("PotenciaCalculada", false);

            //Map(p => p.QtdModuloSugerido)
            //    .ToColumn("QtdModuloSugerido", false);

            Map(p => p.PorcProjeto)
                .ToColumn("Porc_Projeto", false);

            Map(p => p.PorcInstalacao)
                .ToColumn("Porc_Instalacao", false);

            //Map(p => p.IncluiMonitoramento)
            //    .ToColumn("IncluiMonitoramento", false);

            Map(p => p.TipoFrete)
                .ToColumn("Tipo_Frete", false);

            Map(p => p.TipoProposta)
                .ToColumn("Tipo_Proposta", false);

            Map(p => p.ValorKwh)
                .ToColumn("Valor_Kwh", false);

            //Map(p => p.ValorProjetoElsys)
            //    .ToColumn("ValorProjetoElsys", false);

            //Map(p => p.ValorProjetoMargem)
            //    .ToColumn("ValorProjetoMargem", false);

            Map(p => p.UsuarioInclusao)
                .ToColumn("Lg_Us_Inc", false);

            Map(p => p.DataInclusao)
                .ToColumn("Lg_Dt_Inc", false);

            Map(p => p.UsuarioAlteracao)
                .ToColumn("Lg_Us_Alt", false);

            Map(p => p.DataAlteracao)
                .ToColumn("Lg_Dt_Alt", false);

            Map(p => p.IdUsuario)
                .ToColumn("Id_Usuario", false);

            Map(p => p.ValorNFServicoProjeto)
                .ToColumn("Valor_NF_Servico_Projeto", false);

            Map(p => p.ValorNFServicoInstalacao)
                .ToColumn("Valor_NF_Servico_Instalacao", false);

            Map(p => p.IdTipoInversor)
                .ToColumn("Id_Tipo_Inversor", false);

            //Map(p => p.HabilitaSeguro)
            //    .ToColumn("HabilitaSeguro", false);

            Map(p => p.IdCondicaoPagto)
                .ToColumn("Id_CondicaoPagto", false);

            //Map(p => p.ValorProjetoFinal)
            //    .ToColumn("ValorProjetoFinal", false);

            Map(p => p.IdUnidadeProposta)
                .ToColumn("Id_Unidade_Proposta", false);

            Map(p => p.ValorDistribuidorBruto)
                .ToColumn("Valor_Distribuidor_Bruto", false);

            Map(p => p.ValorDistribuidorLiquido)
                .ToColumn("Valor_Distribuidor_Liquido", false);

            //Map(p => p.GuidProposta)
            //    .ToColumn("GuidProposta", false);

            //Map(p => p.PotenciaTotalCalculada)
            //    .ToColumn("PotenciaTotalCalculada", false);
        }
    }
}
