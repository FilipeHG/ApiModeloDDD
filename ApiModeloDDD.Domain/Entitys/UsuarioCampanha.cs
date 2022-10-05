using System;

namespace ApiModeloDDD.Domain.Entitys
{
    public class UsuarioCampanha : Base
    {
        public int UsuarioId { get; set; }
        public int CampanhaId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
