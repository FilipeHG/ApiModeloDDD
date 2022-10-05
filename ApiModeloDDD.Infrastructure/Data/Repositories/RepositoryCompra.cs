using ApiModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiModeloDDD.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApiModeloDDD.Infrastructure.Data.Repositories
{
    public class RepositoryCompra : RepositoryBase<Compra>, IRepositoryCompra
    {
        private readonly Context context;

        public RepositoryCompra(Context context)
            : base(context)
        {
            this.context = context;
        }

        public async Task AtualizarQuantidadeDeCompraDoUsuario(int pedidoId, int quantidade)
        {
            var query = this.context.ProdutoPedido.AsQueryable();
            var queryResult = query.SingleOrDefault(p => p.PedidoId == pedidoId);

            if (queryResult != null)
            {
                queryResult.Quantidade = quantidade;
                this.context.SaveChanges();
            }
        }

        public async Task<int> ObterTotalDeRegistros(string cpf, int? campanhaId)
        {
            var query = BuildQuery(cpf, campanhaId, true);
            query = query.Take(1000);

            return await query.CountAsync();
        }

        public async Task<List<Compra>> ObterComprasPorUsuarioCampanhaIdComPaginacao(string cpf, int? campanhaId, int page, int limit, string sort)
        {
            var startRow = (page - 1) * limit;
            startRow = (startRow > 0) ? startRow : 1;

            var query = BuildQuery(cpf, campanhaId, true);
            query = query.Skip(startRow);

            limit = (limit > 0 && limit <= 1000) ? limit : 1000;
            query = query.Take(limit);

            return await query.ToListAsync();
        }

        private IQueryable<Compra> BuildQuery(string cpf, int? campanhaId, bool? ativo)
        {
            var query = (from pedido in context.Set<Pedido>()
                         join produtoPedido in context.Set<ProdutoPedido>()
                             on pedido.Id equals produtoPedido.PedidoId
                         join produto in context.Set<Produto>()
                             on produtoPedido.CodigoProduto equals produto.CodigoProduto
                         join usuarioCampanha in context.Set<UsuarioCampanha>()
                             on pedido.CampanhaId equals usuarioCampanha.CampanhaId
                         join usuario in context.Set<Usuario>()
                             on usuarioCampanha.UsuarioId equals usuario.Id
                         //where pedido.Ativo == true
                         select new Compra
                         {
                             Usuario = usuario,
                             Pedido = pedido,
                             ProdutoPedido = produtoPedido,
                             Produto = produto
                         });

            if (ativo != null)
                query = query.Where(e => e.Pedido.Ativo == ativo);

            if (campanhaId != null && campanhaId > 0)
                query = query.Where(e => e.Pedido.CampanhaId == campanhaId);

            if (!String.IsNullOrEmpty(cpf))
                query = query.Where(e => e.Usuario.CPF == cpf);

            return query.AsQueryable();
        }
    }
}
