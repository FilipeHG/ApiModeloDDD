using ApiModeloDDD.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceCompra
    {
        Task Add(CompraDto campanhaDto);

        Task Update(CompraDto campanhaDto);

        Task AtualizarQuantidadeDeCompraDoUsuario(int pedidoId, int quantidade);

        Task<IEnumerable<CompraDto>> GetAll();

        Task<CompraDto> GetById(int id);

        Task<int> ObterTotalDeRegistros(string cpf = null, int? campanhaId = null);

        Task<IEnumerable<CompraDto>> ObterComprasPorUsuarioCampanhaIdComPaginacao(string cpf, int? campanhaId, int page, int limit, string sort);
    }
}