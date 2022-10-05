using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryCliente : IRepositoryBase<Cliente>
    {
        Task<int> ObterTotalDeRegistros();

        Task<List<Cliente>> ObterClientesComPaginacao(int page, int limit, string sort);
    }
}
