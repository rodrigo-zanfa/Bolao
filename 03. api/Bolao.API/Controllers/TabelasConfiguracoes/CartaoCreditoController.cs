using Core.Commands;
using Bolao.Domain.Commands.TabelasConfiguracoes;
using Bolao.Service.Interfaces.Services.TabelasConfiguracoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.TabelasConfiguracoes
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class CartaoCreditoController : ControllerBase
    {
        [HttpGet]
        [Route("v1/[controller]")]
        public async Task<IActionResult> GetAllAsync([FromServices] ICartaoCreditoService service)
        {
            var result = await service.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("v1/[controller]/id/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] ICartaoCreditoService service, [FromRoute] int id)
        {
            var result = await service.GetByIdAsync(id);

            return result is not null ? Ok(result) : NoContent();
        }

        [HttpPut]
        [Route("v1/[controller]")]
        public async Task<IActionResult> UpdateAsync([FromServices] ICartaoCreditoService service, [FromBody] UpdateCartaoCreditoCommand command)
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
    }
}
