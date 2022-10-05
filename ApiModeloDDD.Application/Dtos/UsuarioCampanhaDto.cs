using System;

namespace ApiModeloDDD.Application.Dtos
{
    public class UsuarioCampanhaDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int CampanhaId { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
