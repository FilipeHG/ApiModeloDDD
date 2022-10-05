using Microsoft.AspNetCore.Mvc;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Application.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ApiModeloDDD.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IApplicationServiceCliente _applicationServiceCliente;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(IApplicationServiceCliente applicationServiceCliente
            , ILogger<ClientesController> logger)
        {
            this._applicationServiceCliente = applicationServiceCliente;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteDto>> Get([FromQuery] int page, [FromQuery] int limit, [FromQuery] string sort)
        {
            var result = _applicationServiceCliente.ObterClientesComPaginacao(page, limit, sort).Result;
            var totalDeRegistros = _applicationServiceCliente.ObterTotalDeRegistros().Result;

            var paginationResult = new PaginationDto<ClienteDto>(result, totalDeRegistros, page, limit);

            return Ok(paginationResult);
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteDto> Get([FromRoute] int id)
        {
            return Ok(_applicationServiceCliente.GetById(id));
        }
    }
}
