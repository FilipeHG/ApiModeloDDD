using ApiModeloDDD.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceCampanha
    {
        Task<IEnumerable<CampanhaDto>> GetAll();

        Task<CampanhaDto> GetById(int id);

        Task<int> ObterTotalDeRegistros(int? clienteId = null);

        Task<IEnumerable<CampanhaDto>> ObterCampanhasComPaginacao(int page, int limit, string sort);

        Task<IEnumerable<CampanhaDto>> ObterCampanhasPorClienteIdComPaginacao(int clienteId, int page, int limit, string sort);
    }
}