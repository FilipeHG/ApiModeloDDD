using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

namespace ApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingProduto : Profile
    {
        public ModelToDtoMappingProduto()
        {
            ProdutoDtoMap();
        }

        private void ProdutoDtoMap()
        {
            CreateMap<Produto, ProdutoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.CodigoProduto, opt => opt.MapFrom(x => x.CodigoProduto))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(x => x.DisplayName))
                .ForMember(dest => dest.DescricaoLonga, opt => opt.MapFrom(x => x.DescricaoLonga))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(x => x.Ativo))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            //CreateMap<ICollection<Produto>, ObservableCollection<ProdutoDto>>();
        }
    }
}
