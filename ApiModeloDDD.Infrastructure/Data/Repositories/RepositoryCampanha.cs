using ApiModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiModeloDDD.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiModeloDDD.Infrastructure.Data.Repositories
{
    public class RepositoryCampanha : RepositoryBase<Campanha>, IRepositoryCampanha
    {
        private readonly Context context;

        public RepositoryCampanha(Context context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<int> ObterTotalDeRegistros(int? clienteId)
        {
            var query = this.context.Campanha.AsQueryable();
            query = query.Where(e => e.Ativo == true);

            if (clienteId != null)
                query = query.Where(e => e.ClienteId == clienteId.Value);

            query = query.Take(1000);

            return await query.CountAsync();
        }

        public async Task<List<Campanha>> ObterCampanhasComPaginacao(int page, int limit, string sort)
        {
            var startRow = (page - 1) * limit;
            startRow = (startRow > 0) ? startRow : 1;

            var query = this.context.Campanha
                .Where(e => e.Ativo == true)
                .Skip(startRow);

            limit = (limit > 0 && limit <= 1000) ? limit : 1000;
            query = query.Take(limit);

            return await query.ToListAsync();
        }

        public async Task<List<Campanha>> ObterCampanhasPorClienteIdComPaginacao(int clienteId, int page, int limit, string sort)
        {
            var startRow = (page - 1) * limit;
            startRow = (startRow > 0) ? startRow : 1;

            var query = this.context.Campanha
                .Where(e => e.ClienteId == clienteId && e.Ativo == true)
                .Skip(startRow);

            limit = (limit > 0 && limit <= 1000) ? limit : 1000;
            query = query.Take(limit);

            return await query.ToListAsync();
        }
    }
}
