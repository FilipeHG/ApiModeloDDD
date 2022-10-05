using System;

namespace ApiModeloDDD.Application.Dtos
{
    public class CampanhaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ClienteId { get; set; }
        public string Key { get; set; }
        public string ScriptVenda { get; set; }
        public bool PodeEscolherQuantosPontosUtilizar { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}