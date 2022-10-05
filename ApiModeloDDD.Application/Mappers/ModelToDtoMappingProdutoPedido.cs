using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

namespace ApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingProdutoPedido : Profile
    {
        public ModelToDtoMappingProdutoPedido()
        {
            ProdutoPedidoDtoMap();
        }

        private void ProdutoPedidoDtoMap()
        {
            CreateMap<ProdutoPedido, ProdutoPedidoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(x => x.PedidoId))
                .ForMember(dest => dest.CodigoSKU, opt => opt.MapFrom(x => x.CodigoSKU))
                .ForMember(dest => dest.CodigoProduto, opt => opt.MapFrom(x => x.CodigoProduto))
                .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(x => x.Quantidade))
                .ForMember(dest => dest.DescricaoLonga, opt => opt.MapFrom(x => x.DescricaoLonga))
                .ForMember(dest => dest.StatusEntrega, opt => opt.MapFrom(x => x.StatusEntrega))
                .ForMember(dest => dest.Cancelado, opt => opt.MapFrom(x => x.Cancelado))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(x => x.Ativo))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            //CreateMap<ICollection<ProdutoPedido>, ObservableCollection<ProdutoPedidoDto>>();
        }
    }
}
