using Core.Commands;
using Bolao.Domain.Commands.Produtos;
using Bolao.Service.Interfaces.Services.Produtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.Produtos
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        [Route("v1/[controller]")]
        public async Task<IActionResult> GetAllAsync([FromServices] IProdutoService service)
        {
            var result = await service.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("v1/[controller]/id/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] IProdutoService service, [FromRoute] int id)
        {
            var result = await service.GetByIdAsync(id);

            return result is not null ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("v1/[controller]/codigo/{codigo}")]
        public async Task<IActionResult> GetByCodigoAsync([FromServices] IProdutoService service, [FromRoute] string codigo)
        {
            var result = await service.GetByCodigoAsync(codigo);

            return result is not null ? Ok(result) : NoContent();
        }

        [HttpPost]
        [Route("v1/[controller]")]
        public async Task<IActionResult> CreateAsync([FromServices] IProdutoService service, [FromBody] CreateProdutoCommand command)
        {
            try
            {
                var result = (CommandResult)await service.CreateAsync(command);

                return result.Success ? Created($"/", result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("v1/[controller]")]
        public async Task<IActionResult> UpdateAsync([FromServices] IProdutoService service, [FromBody] UpdateProdutoCommand command)
        {
            try
            {
                var result = (CommandResult)await service.UpdateAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("v1/[controller]/{id}/{ativo}/{usuarioAlteracao}")]
        public async Task<IActionResult> UpdateStatusAsync([FromServices] IProdutoService service, [FromRoute] int id, [FromRoute] string ativo, [FromRoute] string usuarioAlteracao)
        {
            try
            {
                var result = (CommandResult)await service.UpdateStatusAsync(id, ativo, usuarioAlteracao);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
