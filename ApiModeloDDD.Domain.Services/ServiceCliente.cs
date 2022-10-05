using ApiModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiModeloDDD.Domain.Core.Interfaces.Services;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Domain.Services
{
    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryCliente _repositoryCliente;

        public ServiceCliente(IRepositoryCliente repositoryCliente)
            : base(repositoryCliente)
        {
            this._repositoryCliente = repositoryCliente;
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            return await this._repositoryCliente.ObterTotalDeRegistros();
        }

        public async Task<List<Cliente>> ObterClientesComPaginacao(int page = 1, int limit = 1000, string sort = "")
        {
            if (page <= 0) page = 1;
            if (limit <= 0) limit = 1000;

            return await this._repositoryCliente.ObterClientesComPaginacao(page, limit, sort);
        }
    }
}