using Bolao.Service.Interfaces.Services.TiposFixacoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.TiposFixacoes
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class TipoFixacaoController : ControllerBase
    {
        [HttpGet]
        [Route("v1/[controller]")]
        public async Task<IActionResult> GetAllAsync([FromServices] ITipoFixacaoService service)
        {
            var result = await service.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }

        [HttpGet]
        [Route("v1/[controller]/marca-estrutura/{idMarcaEstrutura}")]
        public async Task<IActionResult> GetAllByMarcaEstruturaAsync([FromServices] ITipoFixacaoService service, [FromRoute] int idMarcaEstrutura)
        {
            var result = await service.GetAllByMarcaEstruturaAsync(idMarcaEstrutura);

            return result.Any() ? Ok(result) : NoContent();
        }
    }
}
