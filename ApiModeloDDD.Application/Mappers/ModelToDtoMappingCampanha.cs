using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingCampanha : Profile
    {
        public ModelToDtoMappingCampanha()
        {
            CampanhaDtoMap();
        }

        private void CampanhaDtoMap()
        {
            CreateMap<Campanha, CampanhaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(x => x.ClienteId))
                .ForMember(dest => dest.Key, opt => opt.MapFrom(x => x.Key))
                .ForMember(dest => dest.ScriptVenda, opt => opt.MapFrom(x => x.ScriptVenda))
                .ForMember(dest => dest.PodeEscolherQuantosPontosUtilizar, opt => opt.MapFrom(x => x.PodeEscolherQuantosPontosUtilizar))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(x => x.Ativo))
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(x => x.DataInicio))
                .ForMember(dest => dest.DataFim, opt => opt.MapFrom(x => x.DataFim))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            //CreateMap<ICollection<Campanha>, ObservableCollection<CampanhaDto>>();
        }
    }
}
