using Autofac;
using AutoMapper;
using ApiModeloDDD.Application;
using ApiModeloDDD.Application.Interfaces;
using ApiModeloDDD.Application.Mappers;
using ApiModeloDDD.Domain.Core.Interfaces.Repositories;
using ApiModeloDDD.Domain.Core.Interfaces.Services;
using ApiModeloDDD.Domain.Services;
using ApiModeloDDD.Infrastructure.Data.Repositories;

namespace ApiModeloDDD.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
            builder.RegisterType<ApplicationServiceCampanha>().As<IApplicationServiceCampanha>();
            builder.RegisterType<ApplicationServiceCompra>().As<IApplicationServiceCompra>();

            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<ServiceCampanha>().As<IServiceCampanha>();
            builder.RegisterType<ServiceCompra>().As<IServiceCompra>();
            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryCampanha>().As<IRepositoryCampanha>();
            builder.RegisterType<RepositoryCompra>().As<IRepositoryCompra>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingCliente());
                cfg.AddProfile(new ModelToDtoMappingCliente());
                cfg.AddProfile(new DtoToModelMappingCampanha());
                cfg.AddProfile(new ModelToDtoMappingCampanha());
                cfg.AddProfile(new DtoToModelMappingUsuario());
                cfg.AddProfile(new ModelToDtoMappingUsuario());
                cfg.AddProfile(new DtoToModelMappingUsuarioCampanha());
                cfg.AddProfile(new ModelToDtoMappingUsuarioCampanha());
                cfg.AddProfile(new DtoToModelMappingProduto());
                cfg.AddProfile(new ModelToDtoMappingProduto());
                cfg.AddProfile(new DtoToModelMappingPedido());
                cfg.AddProfile(new ModelToDtoMappingPedido());
                cfg.AddProfile(new DtoToModelMappingProdutoPedido());
                cfg.AddProfile(new ModelToDtoMappingProdutoPedido());
                cfg.AddProfile(new DtoToModelMappingCompra());
                cfg.AddProfile(new ModelToDtoMappingCompra());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        #endregion IOC
    }

}