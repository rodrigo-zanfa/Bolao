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
    public class ClasseParceiroController : ControllerBase
    {
        [HttpGet]
        [Route("v1/[controller]")]
        public async Task<IActionResult> GetAllAsync([FromServices] IClasseParceiroService service)
        {
            var result = await service.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpPut]
        [Route("v1/[controller]")]
        public async Task<IActionResult> UpdateAsync([FromServices] IClasseParceiroService service, [FromBody] UpdateClasseParceiroCommand command)
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
