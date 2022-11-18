using Bolao.Service.Interfaces.Services.MarcasEstruturas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolao.API.Controllers.MarcasEstruturas
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class MarcaEstruturaController : ControllerBase
    {
        [HttpGet]
        [Route("v1/[controller]")]
        public async Task<IActionResult> GetAllAsync([FromServices] IMarcaEstruturaService service)
        {
            var result = await service.GetAllAsync();

            return result.Any() ? Ok(result) : NoContent();
        }
    }
}
