using ApiModeloDDD.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        Task<IEnumerable<ClienteDto>> GetAll();

        Task<ClienteDto> GetById(int id);

        Task<int> ObterTotalDeRegistros();

        Task<IEnumerable<ClienteDto>> ObterClientesComPaginacao(int page, int limit, string sort);
    }
}
