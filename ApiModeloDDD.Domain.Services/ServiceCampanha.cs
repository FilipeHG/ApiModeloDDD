using ApiModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiModeloDDD.Domain.Core.Interfaces.Services;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Domain.Services
{
    public class ServiceCampanha : ServiceBase<Campanha>, IServiceCampanha
    {
        private readonly IRepositoryCampanha _repositoryCampanha;

        public ServiceCampanha(IRepositoryCampanha repositoryCampanha)
            : base(repositoryCampanha)
        {
            this._repositoryCampanha = repositoryCampanha;
        }

        public async Task<int> ObterTotalDeRegistros(int? clienteId)
        {
            return await this._repositoryCampanha.ObterTotalDeRegistros(clienteId);
        }

        public async Task<List<Campanha>> ObterCampanhasComPaginacao(int page = 1, int limit = 1000, string sort = "")
        {
            if (page <= 0) page = 1;
            if (limit <= 0) limit = 1000;

            return await this._repositoryCampanha.ObterCampanhasComPaginacao(page, limit, sort);
        }

        public async Task<List<Campanha>> ObterCampanhasPorClienteIdComPaginacao(int clienteId, int page = 1, int limit = 1000, string sort = "")
        {
            if (page <= 0) page = 1;
            if (limit <= 0) limit = 1000;

            return await this._repositoryCampanha.ObterCampanhasPorClienteIdComPaginacao(clienteId, page, limit, sort);
        }
    }
}