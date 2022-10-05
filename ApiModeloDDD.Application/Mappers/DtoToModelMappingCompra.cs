using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApiModeloDDD.Application.Mappers
{
    public class DtoToModelMappingCompra : Profile
    {
        public DtoToModelMappingCompra()
        {
            CompraMap();
        }

        private void CompraMap()
        {
            CreateMap<CompraDto, Compra>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(x => x.Usuario))
                .ForMember(dest => dest.Produto, opt => opt.MapFrom(x => x.Produto))
                .ForMember(dest => dest.Pedido, opt => opt.MapFrom(x => x.Pedido))
                .ForMember(dest => dest.ProdutoPedido, opt => opt.MapFrom(x => x.ProdutoPedido));

            //CreateMap<ICollection<CompraDto>, ObservableCollection<Compra>>();
        }
    }
}
