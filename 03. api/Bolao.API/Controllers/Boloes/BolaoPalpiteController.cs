using Bolao.Domain.Commands.Boloes;
using Bolao.Service.Interfaces.Services.Boloes;
using Core.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.Boloes
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class BolaoPalpiteController : ControllerBase
    {
        [HttpPost]
        [Route("v1/[controller]")]
        public async Task<IActionResult> SaveAsync([FromServices] IBolaoPalpiteService service, [FromBody] CreateBolaoPalpiteCommand command)
        {
            try
            {
                var result = (CommandResult)await service.SaveAsync(command);

                return result.Success ? Created($"/", result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
