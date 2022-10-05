using System;

namespace ApiModeloDDD.Application.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string CodigoProduto { get; set; }
        public string DisplayName { get; set; }
        public string DescricaoLonga { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
