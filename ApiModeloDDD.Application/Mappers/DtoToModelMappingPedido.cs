using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApiModeloDDD.Application.Mappers
{
    public class DtoToModelMappingPedido : Profile
    {
        public DtoToModelMappingPedido()
        {
            PedidoMap();
        }

        private void PedidoMap()
        {
            CreateMap<PedidoDto, Pedido>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(x => x.ClienteId))
                .ForMember(dest => dest.CampanhaId, opt => opt.MapFrom(x => x.CampanhaId))
                .ForMember(dest => dest.CodigoPedido, opt => opt.MapFrom(x => x.CodigoPedido))
                .ForMember(dest => dest.ValorFrete, opt => opt.MapFrom(x => x.ValorFrete))
                .ForMember(dest => dest.ValorFretePontos, opt => opt.MapFrom(x => x.ValorFretePontos))
                .ForMember(dest => dest.ValorTotalProdutos, opt => opt.MapFrom(x => x.ValorTotalProdutos))
                .ForMember(dest => dest.ValorTotalProdutosPontos, opt => opt.MapFrom(x => x.ValorTotalProdutosPontos))
                .ForMember(dest => dest.ValorTotalPedido, opt => opt.MapFrom(x => x.ValorTotalPedido))
                .ForMember(dest => dest.ValorTotalPedidoPontos, opt => opt.MapFrom(x => x.ValorTotalPedidoPontos))
                .ForMember(dest => dest.ValorPagoEmPontos, opt => opt.MapFrom(x => x.ValorPagoEmPontos))
                .ForMember(dest => dest.ValorPagoEmReais, opt => opt.MapFrom(x => x.ValorPagoEmReais))
                .ForMember(dest => dest.ValorPagoEmSubsidio, opt => opt.MapFrom(x => x.ValorPagoEmSubsidio))
                .ForMember(dest => dest.ValorPagoVoucher, opt => opt.MapFrom(x => x.ValorPagoVoucher))
                .ForMember(dest => dest.PrevisaoDeEntrega, opt => opt.MapFrom(x => x.PrevisaoDeEntrega))
                .ForMember(dest => dest.StatusPedido, opt => opt.MapFrom(x => x.StatusPedido))
                .ForMember(dest => dest.Confirmado, opt => opt.MapFrom(x => x.Confirmado))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(x => x.Ativo))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            //CreateMap<ICollection<PedidoDto>, ObservableCollection<Pedido>>();
        }
    }
}
