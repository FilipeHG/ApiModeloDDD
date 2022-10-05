using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceCompra : IServiceBase<Compra>
    {
        Task AtualizarQuantidadeDeCompraDoUsuario(int pedidoId, int quantidade);

        Task<int> ObterTotalDeRegistros(string cpf, int? campanhaId);

        Task<List<Compra>> ObterComprasPorUsuarioCampanhaIdComPaginacao(string cpf, int? campanhaId, int page, int limit, string sort);
    }
}