using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingUsuarioCampanha : Profile
    {
        public ModelToDtoMappingUsuarioCampanha()
        {
            UsuarioCampanhaDtoMap();
        }

        private void UsuarioCampanhaDtoMap()
        {
            CreateMap<UsuarioCampanha, UsuarioCampanhaDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(x => x.UsuarioId))
                .ForMember(dest => dest.CampanhaId, opt => opt.MapFrom(x => x.CampanhaId))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(x => x.Ativo))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            //CreateMap<ICollection<UsuarioCampanha>, ObservableCollection<UsuarioCampanhaDto>>();
        }
    }
}
