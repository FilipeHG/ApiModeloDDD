using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApiModeloDDD.Application.Mappers
{
    public class DtoToModelMappingUsuarioCampanha : Profile
    {
        public DtoToModelMappingUsuarioCampanha()
        {
            UsuarioCampanhaMap();
        }

        private void UsuarioCampanhaMap()
        {
            CreateMap<UsuarioCampanhaDto, UsuarioCampanha>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(x => x.UsuarioId))
                .ForMember(dest => dest.CampanhaId, opt => opt.MapFrom(x => x.CampanhaId))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(x => x.Ativo))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            //CreateMap<ICollection<UsuarioCampanhaDto>, ObservableCollection<UsuarioCampanha>>();
        }
    }
}
