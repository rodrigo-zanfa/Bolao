using Core.Commands;
using Bolao.Domain.Commands.Propostas;
using Bolao.Service.Interfaces.Services.Propostas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.Propostas
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class PropostaController : ControllerBase
    {
        [HttpPost]
        [Route("v1/[controller]/calcular-itens")]
        public async Task<IActionResult> CalcularItensAsync([FromServices] IPropostaService service, [FromBody] CalcularItensCommand command)
        {
            try
            {
                var result = (CommandResult)await service.CalcularItensAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/[controller]/inserir-produto")]
        public async Task<IActionResult> InserirProdutoAsync([FromServices] IPropostaService service, [FromBody] InserirProdutoCommand command)
        {
            try
            {
                var result = (CommandResult)await service.InserirProdutoAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/[controller]/alterar-produto-quantidade")]
        public async Task<IActionResult> AlterarProdutoQuantidadeAsync([FromServices] IPropostaService service, [FromBody] AlterarProdutoQuantidadeCommand command)
        {
            try
            {
                var result = (CommandResult)await service.AlterarProdutoQuantidadeAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/[controller]/excluir-produto")]
        public async Task<IActionResult> ExcluirProdutoAsync([FromServices] IPropostaService service, [FromBody] ExcluirProdutoCommand command)
        {
            try
            {
                var result = (CommandResult)await service.ExcluirProdutoAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/[controller]/alterar-frete")]
        public async Task<IActionResult> AlterarFreteAsync([FromServices] IPropostaService service, [FromBody] AlterarFreteCommand command)
        {
            try
            {
                var result = (CommandResult)await service.AlterarFreteAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/[controller]/alterar-seguro")]
        public async Task<IActionResult> AlterarSeguroAsync([FromServices] IPropostaService service, [FromBody] AlterarSeguroCommand command)
        {
            try
            {
                var result = (CommandResult)await service.AlterarSeguroAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/[controller]/alterar-condicao-pagto")]
        public async Task<IActionResult> AlterarCondicaoPagtoAsync([FromServices] IPropostaService service, [FromBody] AlterarCondicaoPagtoCommand command)
        {
            try
            {
                var result = (CommandResult)await service.AlterarCondicaoPagtoAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/[controller]/alterar-servico")]
        public async Task<IActionResult> AlterarServicoAsync([FromServices] IPropostaService service, [FromBody] AlterarServicoCommand command)
        {
            try
            {
                var result = (CommandResult)await service.AlterarServicoAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
