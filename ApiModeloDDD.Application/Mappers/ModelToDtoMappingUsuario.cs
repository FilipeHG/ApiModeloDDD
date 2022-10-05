using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingUsuario : Profile
    {
        public ModelToDtoMappingUsuario()
        {
            UsuarioDtoMap();
        }

        private void UsuarioDtoMap()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(x => x.CPF))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(x => x.DataNascimento))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(x => x.Sexo))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(x => x.Ativo))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            //CreateMap<ICollection<Usuario>, ObservableCollection<UsuarioDto>>();
        }
    }
}
