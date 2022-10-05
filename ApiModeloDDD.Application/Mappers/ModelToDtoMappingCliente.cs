using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ApiModeloDDD.Application.Mappers
{
    public class ModelToDtoMappingCliente : Profile
    {
        public ModelToDtoMappingCliente()
        {
            ClienteDtoMap();
        }

        private void ClienteDtoMap()
        {
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.CPF, opt => opt.MapFrom(x => x.CPF))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.NomeEmpresa, opt => opt.MapFrom(x => x.NomeEmpresa))
                .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(x => x.CNPJ))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(x => x.Ativo))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(x => x.DataCadastro));

            //CreateMap<ICollection<Cliente>, ObservableCollection<ClienteDto>>();
        }
    }
}
