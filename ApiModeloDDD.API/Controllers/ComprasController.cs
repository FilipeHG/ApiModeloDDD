using Microsoft.AspNetCore.Mvc;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Application.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ApiModeloDDD.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly IApplicationServiceCompra _applicationServiceCompra;
        private readonly ILogger<ComprasController> _logger;

        public ComprasController(IApplicationServiceCompra applicationServiceCompra
            , ILogger<ComprasController> logger)
        {
            this._applicationServiceCompra = applicationServiceCompra;
            this._logger = logger;
        }

        [HttpPut]
        public ActionResult Put([FromBody] CompraDto compraDTO)
        {
            try
            {
                if (compraDTO == null)
                    return NotFound();

                _applicationServiceCompra.Update(compraDTO);
                return Ok("Compra atualizada com sucesso!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("liberarBloquearCompraDoUsuario")]
        public ActionResult<CompraDto> LiberarBloquearCompraDoUsuario([FromBody] ProdutoPedidoDto produtoPedido)
        {
            try
            {
                if (produtoPedido == null || produtoPedido.PedidoId <= 0 || produtoPedido.Quantidade < 0)
                    return NotFound();

                _applicationServiceCompra.AtualizarQuantidadeDeCompraDoUsuario(produtoPedido.PedidoId, produtoPedido.Quantidade);
                return Ok("Compra atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompraDto>> Get([FromQuery] int page, [FromQuery] int limit, [FromQuery] string sort)
        {
            var result = _applicationServiceCompra.ObterComprasPorUsuarioCampanhaIdComPaginacao(null, null, page, limit, sort).Result;
            var totalDeRegistros = _applicationServiceCompra.ObterTotalDeRegistros().Result;

            var paginationResult = new PaginationDto<CompraDto>(result, totalDeRegistros, page, limit);

            return Ok(paginationResult);
        }

        [HttpGet("{id}")]
        public ActionResult<CompraDto> Get([FromRoute] int id)
        {
            return Ok(_applicationServiceCompra.GetById(id));
        }

        [HttpGet("{cpf}/{campanhaId}")]
        public ActionResult<IEnumerable<PaginationDto<CompraDto>>> ObterComprasPorUsuarioCampanhaId([FromRoute] string cpf, [FromRoute] int campanhaId, [FromQuery] int page, [FromQuery] int limit, [FromQuery] string sort)
        {
            var result = _applicationServiceCompra.ObterComprasPorUsuarioCampanhaIdComPaginacao(cpf, campanhaId, page, limit, sort).Result;
            var totalDeRegistros = _applicationServiceCompra.ObterTotalDeRegistros(cpf, campanhaId).Result;

            var paginationResult = new PaginationDto<CompraDto>(result, totalDeRegistros, page, limit);

            return Ok(paginationResult);
        }
    }
}