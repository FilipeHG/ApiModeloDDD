using System;

namespace ApiModeloDDD.Domain.Entitys
{
    public class Produto : Base
    {
        public string CodigoProduto { get; set; }
        public string DisplayName { get; set; }
        public string DescricaoLonga { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
