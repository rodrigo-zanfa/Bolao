using Core.Commands;
using Bolao.Domain.Commands.Propostas;
using Bolao.Domain.Entities.Propostas;
using Bolao.Domain.Enums.Propostas;
using Bolao.Infrastructure.Interfaces.Repositories.Produtos;
using Bolao.Infrastructure.Interfaces.Repositories.Propostas;
using Bolao.Service.Helpers;
using Bolao.Service.Interfaces.Services.Propostas;
using Bolao.Service.Interfaces.Services.TabelasConfiguracoes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Propostas
{
    public class PropostaService : IPropostaService
    {
        private readonly IAuxPropostaRepository _auxPropostaRepository;
        private readonly IAuxPropostaGridRepository _auxPropostaGridRepository;
        private readonly IAuxPropostaServicoRepository _auxPropostaServicoRepository;
        private readonly IAuxPropostaCartaoRepository _auxPropostaCartaoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IConfiguracaoService _configuracaoService;
        private readonly IValidator<CalcularItensCommand> _calcularItensCommandValidator;
        private readonly IValidator<InserirProdutoCommand> _inserirProdutoCommandValidator;
        private readonly IValidator<AlterarProdutoQuantidadeCommand> _alterarProdutoQuantidadeCommandValidator;
        private readonly IValidator<ExcluirProdutoCommand> _excluirProdutoCommandValidator;
        private readonly IValidator<AlterarFreteCommand> _alterarFreteCommandValidator;
        private readonly IValidator<AlterarSeguroCommand> _alterarSeguroCommandValidator;
        private readonly IValidator<AlterarCondicaoPagtoCommand> _alterarCondicaoPagtoCommandValidator;
        private readonly IValidator<AlterarServicoCommand> _alterarServicoCommandValidator;

        public PropostaService(IAuxPropostaRepository auxPropostaRepository, IAuxPropostaGridRepository auxPropostaGridRepository, IAuxPropostaServicoRepository auxPropostaServicoRepository, IAuxPropostaCartaoRepository auxPropostaCartaoRepository, IProdutoRepository produtoRepository, IConfiguracaoService configuracaoService, ICartaoCreditoService cartaoCreditoService, IValidator<CalcularItensCommand> calcularItensCommandValidator, IValidator<InserirProdutoCommand> inserirProdutoCommandValidator, IValidator<AlterarProdutoQuantidadeCommand> alterarProdutoQuantidadeCommandValidator, IValidator<ExcluirProdutoCommand> excluirProdutoCommandValidator, IValidator<AlterarFreteCommand> alterarFreteCommandValidator, IValidator<AlterarSeguroCommand> alterarSeguroCommandValidator, IValidator<AlterarCondicaoPagtoCommand> alterarCondicaoPagtoCommandValidator, IValidator<AlterarServicoCommand> alterarServicoCommandValidator)
        {
            _auxPropostaRepository = auxPropostaRepository;
            _auxPropostaGridRepository = auxPropostaGridRepository;
            _auxPropostaServicoRepository = auxPropostaServicoRepository;
            _auxPropostaCartaoRepository = auxPropostaCartaoRepository;
            _produtoRepository = produtoRepository;
            _configuracaoService = configuracaoService;
            _calcularItensCommandValidator = calcularItensCommandValidator;
            _inserirProdutoCommandValidator = inserirProdutoCommandValidator;
            _alterarProdutoQuantidadeCommandValidator = alterarProdutoQuantidadeCommandValidator;
            _excluirProdutoCommandValidator = excluirProdutoCommandValidator;
            _alterarFreteCommandValidator = alterarFreteCommandValidator;
            _alterarSeguroCommandValidator = alterarSeguroCommandValidator;
            _alterarCondicaoPagtoCommandValidator = alterarCondicaoPagtoCommandValidator;
            _alterarServicoCommandValidator = alterarServicoCommandValidator;
        }

        public async Task<ICommandResult> CalcularItensAsync(CalcularItensCommand command)
        {
            // validação
            //var validation = await _calcularItensCommandValidator.ValidateAsync(command);
            //if (!validation.IsValid)
            //{
            //    var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
            //    return new CommandResult(false, "Não foi possível calcular os itens da Proposta.", new { Errors = mensagensDeErro });
            //}

            // realizar os cálculos dos itens
            var result = await _auxPropostaGridRepository.CalcularItensAsync(command);

            if (!result.Any())
                return new CommandResult(false, "Erro ao calcular os itens da Proposta.", result);

            // calcular os valores caso seja a nova forma de cálculo (após refatoração)
            if (command.RealizarCalculosViaAPI)
            {
                await CalcularValoresAsync(command, result);

                // atualizar os dados após os cálculos
                result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

                await AtualizarAuxPropostaAsync(command.GuidProposta, result.ElementAt(0));
            }

            // retornar o resultado
            return new CommandResult(true, "Proposta calculada com sucesso.", result);
        }

        private async Task<bool> CalcularValoresAsync(CalcularItensCommand command, IEnumerable<AuxPropostaGrid> itensProposta)
        {
            var auxProposta = await _auxPropostaRepository.GetByGuidAsync(command.GuidProposta);

            var margemDistribuidorLojista = await _auxPropostaRepository.GetMargemDistribuidorLojistaAsync(command.IdLoja);

            var configuracao = await _configuracaoService.GetAsync();

            foreach (var itemProposta in itensProposta)
            {
                var produto = await _produtoRepository.GetByCodigoAsync(itemProposta.CodProduto);

                itemProposta.ValorUnitarioProduto = produto.Valor;

                itemProposta.FretePorcentagem = 0;
                if (auxProposta.TipoFrete == "CIF")
                    itemProposta.FretePorcentagem = configuracao.PorcentagemFrete;
                itemProposta.ImpostoPorcentagem = configuracao.PorcentagemImposto;
                itemProposta.InadimplenciaPorcentagem = configuracao.PorcentagemInadimplencia;
                itemProposta.MarketingPorcentagem = configuracao.PorcentagemMarketing;
                itemProposta.GarantiaPorcentagem = configuracao.PorcentagemGarantia;
                itemProposta.SeguroPorcentagem = 0;
                if (auxProposta.HabilitaSeguro == "S")
                    itemProposta.SeguroPorcentagem = configuracao.PorcentagemSeguro;
                itemProposta.CartaoPorcentagem = 0;
                itemProposta.MargemElsysPorcentagem = margemDistribuidorLojista.porcentagemDistribuidor;  // aqui realmente os nomes são invertidos (Distribuidor X Lojista) !!!
                itemProposta.MargemDistribuidorPorcentagem = margemDistribuidorLojista.porcentagemLojista;  // aqui realmente os nomes são invertidos (Distribuidor X Lojista) !!!

                itemProposta.ValorUnitarioBaseCalculo = Math.Round(itemProposta.ValorUnitarioProduto /
                    (1 - ((itemProposta.FretePorcentagem + itemProposta.ImpostoPorcentagem + itemProposta.InadimplenciaPorcentagem + itemProposta.MarketingPorcentagem + itemProposta.GarantiaPorcentagem + itemProposta.SeguroPorcentagem + itemProposta.CartaoPorcentagem + itemProposta.MargemElsysPorcentagem /*+ itemProposta.MargemDistribuidorPorcentagem*/) / 100)), 2);

                itemProposta.FreteValor = 0;
                if (auxProposta.TipoFrete == "CIF")
                    itemProposta.FreteValor = Math.Round(itemProposta.ValorUnitarioBaseCalculo * (itemProposta.FretePorcentagem / 100), 2);
                itemProposta.ImpostoValor = Math.Round(itemProposta.ValorUnitarioBaseCalculo * (itemProposta.ImpostoPorcentagem / 100), 2);
                itemProposta.InadimplenciaValor = Math.Round(itemProposta.ValorUnitarioBaseCalculo * (itemProposta.InadimplenciaPorcentagem / 100), 2);
                itemProposta.MarketingValor = Math.Round(itemProposta.ValorUnitarioBaseCalculo * (itemProposta.MarketingPorcentagem / 100), 2);
                itemProposta.GarantiaValor = Math.Round(itemProposta.ValorUnitarioBaseCalculo * (itemProposta.GarantiaPorcentagem / 100), 2);
                itemProposta.SeguroValor = 0;
                if (auxProposta.HabilitaSeguro == "S")
                    itemProposta.SeguroValor = Math.Round(itemProposta.ValorUnitarioBaseCalculo * (itemProposta.SeguroPorcentagem / 100), 2);
                itemProposta.CartaoValor = 0;
                if (command.TipoCondicaoPagto == (int)CondicaoPagamentoEnum.CartaoCredito)
                    itemProposta.CartaoValor = Math.Round(itemProposta.ValorUnitarioBaseCalculo * (itemProposta.CartaoPorcentagem / 100), 2);
                itemProposta.MargemElsysValor = Math.Round(itemProposta.ValorUnitarioBaseCalculo * (itemProposta.MargemElsysPorcentagem / 100), 2);
                itemProposta.MargemDistribuidorValor = Math.Round(itemProposta.ValorUnitarioBaseCalculo * (itemProposta.MargemDistribuidorPorcentagem / 100), 2);

                #region Sendo com cartão, também é necessário calcular os valores caso opte por pagamento à vista (não basta apenas subtrair o valor do cartão!)

                itemProposta.ValorUnitarioBaseCalculoSemCartao = Math.Round(itemProposta.ValorUnitarioProduto /
                    (1 - ((itemProposta.FretePorcentagem + itemProposta.ImpostoPorcentagem + itemProposta.InadimplenciaPorcentagem + itemProposta.MarketingPorcentagem + itemProposta.GarantiaPorcentagem + itemProposta.SeguroPorcentagem /*+ itemProposta.CartaoPorcentagem */+ itemProposta.MargemElsysPorcentagem /*+ itemProposta.MargemDistribuidorPorcentagem*/) / 100)), 2);

                itemProposta.FreteValorSemCartao = 0;
                if (auxProposta.TipoFrete == "CIF")
                    itemProposta.FreteValorSemCartao = Math.Round(itemProposta.ValorUnitarioBaseCalculoSemCartao * (itemProposta.FretePorcentagem / 100), 2);
                itemProposta.ImpostoValorSemCartao = Math.Round(itemProposta.ValorUnitarioBaseCalculoSemCartao * (itemProposta.ImpostoPorcentagem / 100), 2);
                itemProposta.InadimplenciaValorSemCartao = Math.Round(itemProposta.ValorUnitarioBaseCalculoSemCartao * (itemProposta.InadimplenciaPorcentagem / 100), 2);
                itemProposta.MarketingValorSemCartao = Math.Round(itemProposta.ValorUnitarioBaseCalculoSemCartao * (itemProposta.MarketingPorcentagem / 100), 2);
                itemProposta.GarantiaValorSemCartao = Math.Round(itemProposta.ValorUnitarioBaseCalculoSemCartao * (itemProposta.GarantiaPorcentagem / 100), 2);
                itemProposta.SeguroValorSemCartao = 0;
                if (auxProposta.HabilitaSeguro == "S")
                    itemProposta.SeguroValorSemCartao = Math.Round(itemProposta.ValorUnitarioBaseCalculoSemCartao * (itemProposta.SeguroPorcentagem / 100), 2);
                //itemProposta.CartaoValorSemCartao = 0;
                //if (command.TipoCondicaoPagto == (int)CondicaoPagamentoEnum.CartaoCredito)
                //    itemProposta.CartaoValorSemCartao = Math.Round(itemProposta.ValorUnitarioBaseCalculoSemCartao * (itemProposta.CartaoPorcentagem / 100), 2);
                itemProposta.MargemElsysValorSemCartao = Math.Round(itemProposta.ValorUnitarioBaseCalculoSemCartao * (itemProposta.MargemElsysPorcentagem / 100), 2);
                itemProposta.MargemDistribuidorValorSemCartao = Math.Round(itemProposta.ValorUnitarioBaseCalculoSemCartao * (itemProposta.MargemDistribuidorPorcentagem / 100), 2);

                #endregion

                await _auxPropostaGridRepository.UpdateValoresCalculadosAsync(itemProposta);
            }

            var itemPropostaGrid = itensProposta.ElementAt(0);
            var somaMargemDistribuidorValor = itensProposta.Sum(x => x.QtdDesejada * x.MargemDistribuidorValor);
            var somaMargemDistribuidorValorSemCartao = itensProposta.Sum(x => x.QtdDesejada * x.MargemDistribuidorValorSemCartao);

            var valorNFServicoProjeto = Math.Round((double)auxProposta.PorcProjeto * (1 - (itemPropostaGrid.ImpostoPorcentagem / 100)), 2);
            var valorNFServicoInstalacao = Math.Round((double)auxProposta.PorcInstalacao * (1 - (itemPropostaGrid.ImpostoPorcentagem / 100)), 2);

            var valorBrutoServicos = Math.Round((double)(auxProposta.PorcProjeto + auxProposta.PorcInstalacao), 2);
            var valorRepasseLiquidoServicos = Math.Round(valorBrutoServicos * (1 - (itemPropostaGrid.ImpostoPorcentagem / 100)), 2);
            var valorAdicionalDevidoRepasseServicos = Math.Round((valorBrutoServicos * (1 - (itemPropostaGrid.ImpostoPorcentagem / 100))) /
                (1 - ((itemPropostaGrid.FretePorcentagem + itemPropostaGrid.ImpostoPorcentagem + itemPropostaGrid.SeguroPorcentagem + itemPropostaGrid.CartaoPorcentagem + itemPropostaGrid.MargemElsysPorcentagem) / 100)), 2);

            var valorRepasseLiquidoComissao = Math.Round(somaMargemDistribuidorValor * (1 - (itemPropostaGrid.ImpostoPorcentagem / 100)), 2);
            var valorAdicionalDevidoRepasseComissao = Math.Round((somaMargemDistribuidorValor * (1 - (itemPropostaGrid.ImpostoPorcentagem / 100))) /
                (1 - ((itemPropostaGrid.FretePorcentagem + itemPropostaGrid.ImpostoPorcentagem + itemPropostaGrid.SeguroPorcentagem + itemPropostaGrid.CartaoPorcentagem + itemPropostaGrid.MargemElsysPorcentagem) / 100)), 2);

            #region Sendo com cartão, também é necessário calcular os valores caso opte por pagamento à vista (não basta apenas subtrair o valor do cartão!)

            var valorAdicionalDevidoRepasseServicosSemCartao = Math.Round((valorBrutoServicos * (1 - (itemPropostaGrid.ImpostoPorcentagem / 100))) /
                (1 - ((itemPropostaGrid.FretePorcentagem + itemPropostaGrid.ImpostoPorcentagem + itemPropostaGrid.SeguroPorcentagem /*+ itemPropostaGrid.CartaoPorcentagem*/ + itemPropostaGrid.MargemElsysPorcentagem) / 100)), 2);

            var valorRepasseLiquidoComissaoSemCartao = Math.Round(somaMargemDistribuidorValorSemCartao * (1 - (itemPropostaGrid.ImpostoPorcentagem / 100)), 2);
            var valorAdicionalDevidoRepasseComissaoSemCartao = Math.Round((somaMargemDistribuidorValorSemCartao * (1 - (itemPropostaGrid.ImpostoPorcentagem / 100))) /
                (1 - ((itemPropostaGrid.FretePorcentagem + itemPropostaGrid.ImpostoPorcentagem + itemPropostaGrid.SeguroPorcentagem /*+ itemPropostaGrid.CartaoPorcentagem*/ + itemPropostaGrid.MargemElsysPorcentagem) / 100)), 2);

            #endregion

            await _auxPropostaGridRepository.UpdateValoresCalculadosTotaisAsync(command.GuidProposta, valorNFServicoProjeto, valorNFServicoInstalacao, valorBrutoServicos, valorRepasseLiquidoServicos, valorAdicionalDevidoRepasseServicos,
                valorRepasseLiquidoComissao, valorAdicionalDevidoRepasseComissao, valorAdicionalDevidoRepasseServicosSemCartao, valorRepasseLiquidoComissaoSemCartao, valorAdicionalDevidoRepasseComissaoSemCartao);

            return true;
        }

        private async Task<bool> AtualizarAuxPropostaAsync(string guidProposta, AuxPropostaGrid auxPropostaGrid)
        {
            var auxProposta = await _auxPropostaRepository.GetByGuidAsync(guidProposta);

            auxProposta.ValorProjetoElsys = auxPropostaGrid.TotalSubtotal;
            auxProposta.ValorProjetoMargem = auxPropostaGrid.TotalSubtotalComMargem;
            auxProposta.ValorNFServicoProjeto = auxPropostaGrid.ValorNFServicoProjeto;
            auxProposta.ValorNFServicoInstalacao = auxPropostaGrid.ValorNFServicoInstalacao;
            auxProposta.ValorProjetoFinal = auxPropostaGrid.ValorProjetoFinal;
            auxProposta.ValorDistribuidorBruto = 0;
            auxProposta.ValorDistribuidorLiquido = 0;

            await _auxPropostaRepository.UpdateAsync(auxProposta);

            return true;
        }

        public async Task<ICommandResult> InserirProdutoAsync(InserirProdutoCommand command)
        {
            // validação
            var validation = await _inserirProdutoCommandValidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível inserir o item da Proposta.", new { Errors = mensagensDeErro });
            }

            #region Inserção ou alteração dos dados referentes aos serviços

            // validação de chave existente
            var entityExistente = await _auxPropostaGridRepository.GetByCodigoAsync(command.GuidProposta, command.CodProduto);
            if (entityExistente is null)
            {
                var produto = await _produtoRepository.GetByCodigoAsync(command.CodProduto);

                // selecionar todos os itens da proposta, para pegar o primeiro como "modelo"
                var itens = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

                // inserir
                entityExistente = new AuxPropostaGrid
                {
                    IdLoja = itens.ElementAt(0).IdLoja,
                    IdUsuario = itens.ElementAt(0).IdUsuario,
                    Descricao = produto.Descricao,
                    PrecoUnitario = produto.Valor,
                    Quantidade = command.QtdDesejada,
                    //Subtotal = 0,
                    //PrecoUnitarioComMargem = 0,
                    QtdDesejada = command.QtdDesejada,
                    //SubtotalComMargem = 0,
                    Potencia = itens.ElementAt(0).Potencia,
                    QtdModulo = itens.ElementAt(0).QtdModulo,
                    //TotalSubtotal = 0,
                    //TotalSubtotalComMargem = 0,
                    //PorcDesconto = 0,
                    //PrecoUnitarioDesconto = 0,
                    IdTabela = itens.ElementAt(0).IdTabela,
                    CodProduto = command.CodProduto,
                    //ValorNFServicoProjeto = 0,
                    //ValorNFServicoInstalacao = 0,
                    //ValorProjetoFinal = 0,
                    //DescricaoTipo = "",
                    Modelo = produto.Modelo,
                    Marca = produto.Marca,
                    Unidade = produto.Unidade,
                    GuidProposta = command.GuidProposta//,
                    //PrecoUnitarioFixo = 0
                };

                // salvar
                await _auxPropostaGridRepository.CreateAsync(entityExistente);
            }
            else
            {
                // alterar os atributos necessários
                entityExistente.Quantidade += command.QtdDesejada;
                entityExistente.QtdDesejada += command.QtdDesejada;

                // salvar
                await _auxPropostaGridRepository.UpdateAsync(entityExistente);
            }

            #endregion

            // selecionar todos os itens da proposta
            var result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await CalcularValoresAsync(
                new CalcularItensCommand()
                {
                    IdLoja = (int)entityExistente.IdLoja,
                    TipoCondicaoPagto = result.ElementAt(0).IdCondicaoPagto,
                    GuidProposta = command.GuidProposta
                }, result);

            // atualizar os dados após os cálculos
            result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await AtualizarAuxPropostaAsync(command.GuidProposta, result.ElementAt(0));

            // retornar o resultado
            return new CommandResult(true, "Item da Proposta inserido com sucesso.", result);
        }

        public async Task<ICommandResult> AlterarProdutoQuantidadeAsync(AlterarProdutoQuantidadeCommand command)
        {
            // validação
            var validation = await _alterarProdutoQuantidadeCommandValidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível alterar a Quantidade do item da Proposta.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _auxPropostaGridRepository.GetByIdAsync(command.IdAux);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Item da Proposta não encontrado para atualização.", entityExistente);
            }

            // alterar os atributos necessários
            entityExistente.Quantidade = command.QtdDesejada;
            entityExistente.QtdDesejada = command.QtdDesejada;

            // salvar
            await _auxPropostaGridRepository.UpdateAsync(entityExistente);

            // selecionar todos os itens da proposta
            var result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await CalcularValoresAsync(
                new CalcularItensCommand()
                {
                    IdLoja = (int)entityExistente.IdLoja,
                    TipoCondicaoPagto = (int)entityExistente.IdCondicaoPagto,
                    GuidProposta = command.GuidProposta
                }, result);

            // atualizar os dados após os cálculos
            result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await AtualizarAuxPropostaAsync(command.GuidProposta, result.ElementAt(0));

            // retornar o resultado
            return new CommandResult(true, "Quantidade do item da Proposta alterada com sucesso.", result);
        }

        public async Task<ICommandResult> ExcluirProdutoAsync(ExcluirProdutoCommand command)
        {
            // validação
            var validation = await _excluirProdutoCommandValidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível excluir o item da Proposta.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _auxPropostaGridRepository.GetByIdAsync(command.IdAux);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Item da Proposta não encontrado para exclusão.", entityExistente);
            }

            // salvar
            await _auxPropostaGridRepository.DeleteAsync(command.IdAux);

            // selecionar todos os itens da proposta
            var result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await CalcularValoresAsync(
                new CalcularItensCommand()
                {
                    IdLoja = (int)entityExistente.IdLoja,
                    TipoCondicaoPagto = (int)entityExistente.IdCondicaoPagto,
                    GuidProposta = command.GuidProposta
                }, result);

            // atualizar os dados após os cálculos
            result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await AtualizarAuxPropostaAsync(command.GuidProposta, result.ElementAt(0));

            // retornar o resultado
            return new CommandResult(true, "Item da Proposta excluído com sucesso.", result);
        }

        public async Task<ICommandResult> AlterarFreteAsync(AlterarFreteCommand command)
        {
            // validação
            var validation = await _alterarFreteCommandValidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível alterar o Tipo de Frete da Proposta.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _auxPropostaRepository.GetByGuidAsync(command.GuidProposta);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Proposta não encontrada para atualização.", entityExistente);
            }

            // alterar os atributos necessários
            entityExistente.TipoFrete = command.TipoFrete;

            // salvar
            await _auxPropostaRepository.UpdateAsync(entityExistente);

            // selecionar todos os itens da proposta
            var result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await CalcularValoresAsync(
                new CalcularItensCommand()
                {
                    IdLoja = (int)entityExistente.IdLoja,
                    TipoCondicaoPagto = (int)entityExistente.IdCondicaoPagto,
                    GuidProposta = command.GuidProposta
                }, result);

            // atualizar os dados após os cálculos
            result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await AtualizarAuxPropostaAsync(command.GuidProposta, result.ElementAt(0));

            // retornar o resultado
            return new CommandResult(true, "Tipo de Frete da Proposta alterado com sucesso.", result);
        }

        public async Task<ICommandResult> AlterarSeguroAsync(AlterarSeguroCommand command)
        {
            // validação
            var validation = await _alterarSeguroCommandValidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível alterar o Seguro da Proposta.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _auxPropostaRepository.GetByGuidAsync(command.GuidProposta);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Proposta não encontrada para atualização.", entityExistente);
            }

            // alterar os atributos necessários
            entityExistente.HabilitaSeguro = command.HabilitaSeguro ? "S" : "N";

            // salvar
            await _auxPropostaRepository.UpdateAsync(entityExistente);

            // selecionar todos os itens da proposta
            var result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await CalcularValoresAsync(
                new CalcularItensCommand()
                {
                    IdLoja = (int)entityExistente.IdLoja,
                    TipoCondicaoPagto = (int)entityExistente.IdCondicaoPagto,
                    GuidProposta = command.GuidProposta
                }, result);

            // atualizar os dados após os cálculos
            result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await AtualizarAuxPropostaAsync(command.GuidProposta, result.ElementAt(0));

            // retornar o resultado
            return new CommandResult(true, "Seguro da Proposta alterado com sucesso.", result);
        }

        public async Task<ICommandResult> AlterarCondicaoPagtoAsync(AlterarCondicaoPagtoCommand command)
        {
            // validação
            var validation = await _alterarCondicaoPagtoCommandValidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível alterar a Condição de Pagamento da Proposta.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _auxPropostaRepository.GetByGuidAsync(command.GuidProposta);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Proposta não encontrada para atualização.", entityExistente);
            }

            // alterar os atributos necessários
            entityExistente.IdCondicaoPagto = command.IdCondicaoPagto;

            // salvar
            await _auxPropostaRepository.UpdateAsync(entityExistente);

            #region Inserção ou alteração dos dados referentes ao cartão de crédito

            if (command.IdCondicaoPagto == (int)CondicaoPagamentoEnum.CartaoCredito)
            {
                // validação de chave existente
                var entityExistenteCartao = await _auxPropostaCartaoRepository.GetByUniqueKeyAsync(/*command.IdUsuario, command.IdLoja, */command.GuidProposta);
                if (entityExistenteCartao is null)
                {
                    // inserir
                    entityExistenteCartao = new AuxPropostaCartao
                    {
                        IdOperadora = command.IdOperadora,
                        QuantidadeParcelas = command.QuantidadeParcelas,
                        IdUsuario = command.IdUsuario,
                        IdLoja = command.IdLoja,
                        GuidProposta = command.GuidProposta
                    };

                    // salvar
                    await _auxPropostaCartaoRepository.CreateAsync(entityExistenteCartao);
                }
                else
                {
                    // alterar os atributos necessários
                    entityExistenteCartao.IdOperadora = command.IdOperadora;
                    entityExistenteCartao.QuantidadeParcelas = command.QuantidadeParcelas;

                    // salvar
                    await _auxPropostaCartaoRepository.UpdateAsync(entityExistenteCartao);
                }
            }

            #endregion

            // selecionar todos os itens da proposta
            var result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await CalcularValoresAsync(
                new CalcularItensCommand()
                {
                    IdLoja = (int)entityExistente.IdLoja,
                    TipoCondicaoPagto = (int)entityExistente.IdCondicaoPagto,
                    GuidProposta = command.GuidProposta
                }, result);

            // atualizar os dados após os cálculos
            result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await AtualizarAuxPropostaAsync(command.GuidProposta, result.ElementAt(0));

            // retornar o resultado
            return new CommandResult(true, "Condição de Pagamento da Proposta alterada com sucesso.", result);
        }

        public async Task<ICommandResult> AlterarServicoAsync(AlterarServicoCommand command)
        {
            // validação
            var validation = await _alterarServicoCommandValidator.ValidateAsync(command);
            if (!validation.IsValid)
            {
                var mensagensDeErro = ValidationErrorMessagesHelper.GetMessages(validation.Errors);
                return new CommandResult(false, "Não foi possível alterar os Serviços da Proposta.", new { Errors = mensagensDeErro });
            }

            // validação de chave existente
            var entityExistente = await _auxPropostaRepository.GetByGuidAsync(command.GuidProposta);
            if (entityExistente is null)
            {
                return new CommandResult(false, "Proposta não encontrada para atualização.", entityExistente);
            }

            // alterar os atributos necessários
            entityExistente.PorcProjeto = command.ValorProjeto;
            entityExistente.PorcInstalacao = command.ValorInstalacao;

            // salvar
            await _auxPropostaRepository.UpdateAsync(entityExistente);

            #region Inserção ou alteração dos dados referentes aos serviços

            // validação de chave existente
            var entityExistenteServico = await _auxPropostaServicoRepository.GetByUniqueKeyAsync(/*command.IdUsuario, command.IdLoja, */command.GuidProposta);
            if (entityExistenteServico is null)
            {
                // inserir
                entityExistenteServico = new AuxPropostaServico
                {
                    ValorProjeto = command.ValorProjeto,
                    ValorInstalacao = command.ValorInstalacao,
                    IdUsuario = command.IdUsuario,
                    IdLoja = command.IdLoja,
                    GuidProposta = command.GuidProposta
                };

                // salvar
                await _auxPropostaServicoRepository.CreateAsync(entityExistenteServico);
            }
            else
            {
                // alterar os atributos necessários
                entityExistenteServico.ValorProjeto = command.ValorProjeto;
                entityExistenteServico.ValorInstalacao = command.ValorInstalacao;

                // salvar
                await _auxPropostaServicoRepository.UpdateAsync(entityExistenteServico);
            }

            #endregion

            // selecionar todos os itens da proposta
            var result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await CalcularValoresAsync(
                new CalcularItensCommand()
                {
                    IdLoja = (int)entityExistente.IdLoja,
                    TipoCondicaoPagto = (int)entityExistente.IdCondicaoPagto,
                    GuidProposta = command.GuidProposta
                }, result);

            // atualizar os dados após os cálculos
            result = await _auxPropostaGridRepository.GetAllByGuidAsync(command.GuidProposta);

            await AtualizarAuxPropostaAsync(command.GuidProposta, result.ElementAt(0));

            // retornar o resultado
            return new CommandResult(true, "Serviços da Proposta alterados com sucesso.", result);
        }
    }
}
