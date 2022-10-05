using System;

namespace ApiModeloDDD.Domain.Entitys
{
    public class Compra
    {
        public Usuario Usuario { get; set; }

        public Pedido Pedido { get; set; }

        public Produto Produto { get; set; }

        public ProdutoPedido ProdutoPedido { get; set; }
    }
}
