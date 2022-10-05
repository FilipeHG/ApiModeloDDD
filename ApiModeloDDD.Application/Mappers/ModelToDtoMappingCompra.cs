using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

namespace ApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingCompra : Profile
    {
        public ModelToDtoMappingCompra()
        {
            CompraDtoMap();
        }

        private void CompraDtoMap()
        {
            CreateMap<Compra, CompraDto>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(x => x.Usuario))
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(x => x.Produto))
                .ForMember(dest => dest.Pedido, opt => opt.MapFrom(x => x.Pedido))
                .ForMember(dest => dest.ProdutoPedido, opt => opt.MapFrom(x => x.ProdutoPedido));

            //CreateMap<ICollection<Compra>, ObservableCollection<CompraDto>>();
        }
    }
}
