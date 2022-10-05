using System;

namespace ApiModeloDDD.Application.Dtos
{
    public class CompraDto
    {
        public UsuarioDto Usuario { get; set; }

        public PedidoDto Pedido { get; set; }

        public ProdutoDto Produto { get; set; }

        public ProdutoPedidoDto ProdutoPedido { get; set; }
    }
}
