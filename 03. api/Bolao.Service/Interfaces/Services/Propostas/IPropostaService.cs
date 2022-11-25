using Core.Commands;
using Bolao.Domain.Commands.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Propostas
{
    public interface IPropostaService
    {
        Task<ICommandResult> CalcularItensAsync(CalcularItensCommand command);
        Task<ICommandResult> InserirProdutoAsync(InserirProdutoCommand command);
        Task<ICommandResult> AlterarProdutoQuantidadeAsync(AlterarProdutoQuantidadeCommand command);
        Task<ICommandResult> ExcluirProdutoAsync(ExcluirProdutoCommand command);
        Task<ICommandResult> AlterarFreteAsync(AlterarFreteCommand command);
        Task<ICommandResult> AlterarSeguroAsync(AlterarSeguroCommand command);
        Task<ICommandResult> AlterarCondicaoPagtoAsync(AlterarCondicaoPagtoCommand command);
        Task<ICommandResult> AlterarServicoAsync(AlterarServicoCommand command);
    }
}
