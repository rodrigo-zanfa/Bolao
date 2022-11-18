using Core.Commands;
using Bolao.Domain.Commands.ClassesParceiros;
using Bolao.Service.Interfaces.Services.ClassesParceiros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.ClassesParceiros
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class ClasseParceiroDistribuidorController : ControllerBase
    {
        [HttpGet]
        [Route("v1/[controller]")]
        public async Task<IActionResult> GetAllAsync([FromServices] IClasseParceiroDistribuidorService service)
        {
            var result = await service.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("v1/[controller]/id/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] IClasseParceiroDistribuidorService service, [FromRoute] int id)
        {
            var result = await service.GetByIdAsync(id);

            return result is not null ? Ok(result) : NoContent();
        }

        [HttpPost]
        [Route("v1/[controller]")]
        public async Task<IActionResult> CreateAsync([FromServices] IClasseParceiroDistribuidorService service, [FromBody] CreateClasseParceiroDistribuidorCommand command)
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
        public async Task<IActionResult> UpdateAsync([FromServices] IClasseParceiroDistribuidorService service, [FromBody] UpdateClasseParceiroDistribuidorCommand command)
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
        [Route("v1/[controller]/{idClasseParceiroDistribuidor}/{idClasseParceiro}")]
        public async Task<IActionResult> UpdateClasseAsync([FromServices] IClasseParceiroDistribuidorService service, [FromRoute] int idClasseParceiroDistribuidor, [FromRoute] int idClasseParceiro)
        {
            try
            {
                var result = (CommandResult)await service.UpdateClasseAsync(idClasseParceiroDistribuidor, idClasseParceiro);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
