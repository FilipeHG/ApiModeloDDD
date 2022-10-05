using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Application.Interfaces;
using ApiModeloDDD.Domain.Core.Interfaces.Services;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ApiModeloDDD.Application
{
    public class ApplicationServiceCompra : IApplicationServiceCompra
    {
        private readonly IServiceCompra _serviceCompra;
        private readonly IMapper _mapper;

        public ApplicationServiceCompra(IServiceCompra serviceCompra,
            IMapper mapper)
        {
            this._serviceCompra = serviceCompra;
            this._mapper = mapper;
        }

        public async Task Add(CompraDto compraDto)
        {
            var compra = _mapper.Map<Compra>(compraDto);
            await this._serviceCompra.Add(compra);
        }

        public async Task Update(CompraDto compraDto)
        {
            var compra = _mapper.Map<Compra>(compraDto);
            await this._serviceCompra.Update(compra);
        }

        public async Task AtualizarQuantidadeDeCompraDoUsuario(int pedidoId, int quantidade)
        {
            await this._serviceCompra.AtualizarQuantidadeDeCompraDoUsuario(pedidoId, quantidade);
        }

        public async Task<IEnumerable<CompraDto>> GetAll()
        {
            var compras = await this._serviceCompra.GetAll();
            var comprasDto = _mapper.Map<IEnumerable<CompraDto>>(compras);
            
            return comprasDto;
        }

        public async Task<CompraDto> GetById(int id)
        {
            var compra = await this._serviceCompra.GetById(id);
            var compraDto = _mapper.Map<CompraDto>(compra);
            
            return compraDto;
        }

        public async Task<int> ObterTotalDeRegistros(string cpf, int? campanhaId)
        {
            var total = await this._serviceCompra.ObterTotalDeRegistros(cpf, campanhaId);
            return total;
        }

        public async Task<IEnumerable<CompraDto>> ObterComprasPorUsuarioCampanhaIdComPaginacao(string cpf, int? campanhaId, int page, int limit, string sort)
        {
            var compras = await this._serviceCompra.ObterComprasPorUsuarioCampanhaIdComPaginacao(cpf, campanhaId, page, limit, sort);
            //var comprasDto = _mapper.Map<IEnumerable<CompraDto>>(compras);

            IEnumerable<CompraDto> comprasDto = new List<CompraDto>();
            if (compras != null && compras.Any())
            {
                var comprasDtoMapped = new List<CompraDto>();
                foreach (var compra in compras)
                {
                    var usuarioDto = _mapper.Map<UsuarioDto>(compra.Usuario);
                    var pedidoDto = _mapper.Map<PedidoDto>(compra.Pedido);
                    var produtoDto = _mapper.Map<ProdutoDto>(compra.Produto);
                    var produtoPedidoDto = _mapper.Map<ProdutoPedidoDto>(compra.ProdutoPedido);

                    comprasDtoMapped.Add(new CompraDto() {
                        Usuario = usuarioDto,
                        Pedido = pedidoDto,
                        Produto = produtoDto,
                        ProdutoPedido = produtoPedidoDto
                    });
                }

                comprasDto = comprasDtoMapped;
            }

            return comprasDto;
        }
    }
}