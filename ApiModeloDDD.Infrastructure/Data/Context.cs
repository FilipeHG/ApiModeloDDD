using Microsoft.EntityFrameworkCore;
using ApiModeloDDD.Domain.Entitys;
using System;
using System.Linq;

namespace ApiModeloDDD.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new Mappings.TokenMapping());

        //    base.OnModelCreating(modelBuilder);
        //}

        //public override int SaveChanges()
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        //        }
        //        if (entry.State == EntityState.Modified)
        //        {
        //            entry.Property("DataCadastro").IsModified = false;
        //        }
        //    }
        //    return base.SaveChanges();
        //}

        public virtual DbSet<Cliente> Cliente { get; set; }

        public virtual DbSet<Campanha> Campanha { get; set; }

        public virtual DbSet<Pedido> Pedido { get; set; }

        public virtual DbSet<Produto> Produto { get; set; }

        public virtual DbSet<ProdutoPedido> ProdutoPedido { get; set; }

        public virtual DbSet<Usuario> Usuario { get; set; }

        public virtual DbSet<UsuarioCampanha> UsuarioCampanha { get; set; }
    }
}