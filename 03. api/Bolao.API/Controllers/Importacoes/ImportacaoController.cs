using Bolao.Service.Interfaces.Services.Importacoes;
using Core.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.Importacoes
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class ImportacaoController : ControllerBase
    {
        [HttpPost]
        [Route("v1/[controller]/importar-copa-2022")]
        public async Task<IActionResult> ImportarCopa2022Async([FromServices] IImportacaoService service)
        {
            try
            {
                var result = (CommandResult)await service.ImportarCopa2022Async();

                return result.Success ? Ok(result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
