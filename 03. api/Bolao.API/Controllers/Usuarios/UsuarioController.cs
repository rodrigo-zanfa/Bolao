using Bolao.Domain.Commands.Usuarios;
using Bolao.Service.Interfaces.Services.Usuarios;
using Core.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.Usuarios
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("v1/[controller]")]
        public async Task<IActionResult> CreateAsync([FromServices] IUsuarioService service, [FromBody] CreateUsuarioCommand command)
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
    }
}
