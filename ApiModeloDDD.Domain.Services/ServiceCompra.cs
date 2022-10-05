using ApiModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiModeloDDD.Domain.Core.Interfaces.Services;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Domain.Services
{
    public class ServiceCompra : ServiceBase<Compra>, IServiceCompra
    {
        private readonly IRepositoryCompra _repositoryCompra;

        public ServiceCompra(IRepositoryCompra repositoryCompra)
            : base(repositoryCompra)
        {
            this._repositoryCompra = repositoryCompra;
        }

        public async Task AtualizarQuantidadeDeCompraDoUsuario(int pedidoId, int quantidade)
        {
            await this._repositoryCompra.AtualizarQuantidadeDeCompraDoUsuario(pedidoId, quantidade);
        }

        public async Task<int> ObterTotalDeRegistros(string cpf, int? campanhaId)
        {            
            return await this._repositoryCompra.ObterTotalDeRegistros(cpf, campanhaId);
        }

        public async Task<List<Compra>> ObterComprasPorUsuarioCampanhaIdComPaginacao(string cpf, int? campanhaId, int page = 1, int limit = 1000, string sort = "")
        {
            if (page <= 0) page = 1;
            if (limit <= 0) limit = 1000;

            return await this._repositoryCompra.ObterComprasPorUsuarioCampanhaIdComPaginacao(cpf, campanhaId, page, limit, sort);
        }
    }
}