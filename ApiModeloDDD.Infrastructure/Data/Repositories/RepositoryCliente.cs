using ApiModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiModeloDDD.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiModeloDDD.Infrastructure.Data.Repositories
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        private readonly Context context;

        public RepositoryCliente(Context context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            var query = this.context.Cliente.AsQueryable();
            query = query.Where(e => e.Ativo == true);
            query = query.Take(1000);

            return await query.CountAsync();
        }

        public async Task<List<Cliente>> ObterClientesComPaginacao(int page, int limit, string sort)
        {
            var startRow = (page - 1) * limit;
            startRow = (startRow > 0) ? startRow : 1;

            var query = this.context.Cliente
                .Where(e => e.Ativo == true)
                .Skip(startRow);

            limit = (limit > 0 && limit <= 1000) ? limit : 1000;
            query = query.Take(limit);

            return await query.ToListAsync();
        }
    }
}