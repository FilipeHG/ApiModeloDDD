using System;

namespace ApiModeloDDD.Domain.Entitys
{
    public class ProdutoPedido : Base
    {
        public int PedidoId { get; set; }
        public string CodigoSKU { get; set; }
        public string CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public string DescricaoLonga { get; set; }
        public string StatusEntrega { get; set; }
        public bool Cancelado { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
