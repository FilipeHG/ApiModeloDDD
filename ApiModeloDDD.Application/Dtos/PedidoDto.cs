using System;

namespace ApiModeloDDD.Application.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int CampanhaId { get; set; }
        public long CodigoPedido { get; set; }
        public decimal? ValorFrete { get; set; }
        public decimal? ValorFretePontos { get; set; }
        public decimal? ValorTotalProdutos { get; set; }
        public decimal? ValorTotalProdutosPontos { get; set; }
        public decimal? ValorTotalPedido { get; set; }
        public decimal? ValorTotalPedidoPontos { get; set; }
        public decimal? ValorPagoEmPontos { get; set; }
        public decimal? ValorPagoEmReais { get; set; }
        public decimal? ValorPagoEmSubsidio { get; set; }
        public decimal? ValorPagoVoucher { get; set; }
        public string PrevisaoDeEntrega { get; set; }
        public string StatusPedido { get; set; }
        public bool Confirmado { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
