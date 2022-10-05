using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceCampanha : IServiceBase<Campanha>
    {
        Task<int> ObterTotalDeRegistros(int? clienteId);

        Task<List<Campanha>> ObterCampanhasComPaginacao(int page, int limit, string sort);

        Task<List<Campanha>> ObterCampanhasPorClienteIdComPaginacao(int clienteId, int page, int limit, string sort);
    }
}