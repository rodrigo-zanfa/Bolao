using Bolao.Domain.Commands.Campeonatos;
using Bolao.Service.Interfaces.Services.Campeonatos;
using Core.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.Campeonatos
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class CampeonatoPartidaController : ControllerBase
    {
        [HttpPut]
        [Route("v1/[controller]")]
        public async Task<IActionResult> UpdatePlacarAsync([FromServices] ICampeonatoPartidaService service, [FromBody] UpdatePlacarCampeonatoPartidaCommand command)
        {
            try
            {
                var result = (CommandResult)await service.UpdatePlacarAsync(command);

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("v1/[controller]")]
        public async Task<IActionResult> GerarPontuacaoPorPartidaAsync([FromServices] ICampeonatoPartidaService service, [FromBody] GerarPontuacaoPorPartidaCommand command)
        {
            try
            {
                var result = (CommandResult)await service.GerarPontuacaoPorPartidaAsync(command);

                return result.Success ? Created($"/", result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
