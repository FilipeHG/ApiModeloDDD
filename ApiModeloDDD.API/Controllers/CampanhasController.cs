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
    public class CampanhasController : ControllerBase
    {
        private readonly IApplicationServiceCampanha _applicationServiceCampanha;
        private readonly ILogger<CampanhasController> _logger;

        public CampanhasController(IApplicationServiceCampanha applicationServiceCampanha
            ,ILogger<CampanhasController> logger)
        {
            this._applicationServiceCampanha = applicationServiceCampanha;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CampanhaDto>> Get([FromQuery] int page, [FromQuery] int limit, [FromQuery] string sort)
        {
            var result = _applicationServiceCampanha.ObterCampanhasComPaginacao(page, limit, sort).Result;
            var totalDeRegistros = _applicationServiceCampanha.ObterTotalDeRegistros().Result;

            var paginationResult = new PaginationDto<CampanhaDto>(result, totalDeRegistros, page, limit);

            return Ok(paginationResult);
        }

        [HttpGet("{id}")]
        public ActionResult<CampanhaDto> Get([FromRoute] int id)
        {
            return Ok(_applicationServiceCampanha.GetById(id));
        }

        [HttpGet("cliente/{clienteId}")]
        public ActionResult<IEnumerable<PaginationDto<CampanhaDto>>> ObterCampanhasPorClienteId([FromRoute] int clienteId, [FromQuery] int page, [FromQuery] int limit, [FromQuery] string sort)
        {
            var result = _applicationServiceCampanha.ObterCampanhasPorClienteIdComPaginacao(clienteId, page, limit, sort).Result;
            var totalDeRegistros = _applicationServiceCampanha.ObterTotalDeRegistros(clienteId).Result;

            var paginationResult = new PaginationDto<CampanhaDto>(result, totalDeRegistros, page, limit);

            return Ok(paginationResult);
        }
    }
}