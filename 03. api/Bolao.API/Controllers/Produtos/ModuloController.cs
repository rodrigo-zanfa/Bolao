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
    public class ModuloController : ControllerBase
    {
        [HttpGet]
        [Route("v1/[controller]")]
        public async Task<IActionResult> GetAllAsync([FromServices] IModuloService service)
        {
            var result = await service.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("v1/[controller]/id/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromServices] IModuloService service, [FromRoute] int id)
        {
            var result = await service.GetByIdAsync(id);

            return result is not null ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("v1/[controller]/codigo/{codigo}")]
        public async Task<IActionResult> GetByCodigoAsync([FromServices] IModuloService service, [FromRoute] string codigo)
        {
            var result = await service.GetByCodigoAsync(codigo);

            return result is not null ? Ok(result) : NoContent();
        }

        //[HttpPost]
        //[Route("v1/[controller]")]
        //public async Task<IActionResult> CreateAsync([FromServices] IModuloService service, [FromBody] CreateModuloCommand command)
        //{
        //    var result = (CommandResult)await service.CreateAsync(command);

        //    return result.Success ? Created($"/", result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        //}

        //[HttpPut]
        //[Route("v1/[controller]")]
        //public async Task<IActionResult> UpdateAsync([FromServices] IModuloService service, [FromBody] UpdateModuloCommand command)
        //{
        //    var result = (CommandResult)await service.UpdateAsync(command);

        //    return result.Success ? Ok(result) : StatusCode(StatusCodes.Status500InternalServerError, result);
        //}
    }
}
