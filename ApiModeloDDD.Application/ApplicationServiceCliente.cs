using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Application.Interfaces;
using ApiModeloDDD.Domain.Core.Interfaces.Services;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente _serviceCliente;
        private readonly IMapper _mapper;

        public ApplicationServiceCliente(IServiceCliente serviceCliente,
            IMapper mapper)
        {
            this._serviceCliente = serviceCliente;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> GetAll()
        {
            var clientes = await this._serviceCliente.GetAll();
            var clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

            return clientesDto;
        }

        public async Task<ClienteDto> GetById(int id)
        {
            var cliente = await this._serviceCliente.GetById(id);
            var clienteDto = _mapper.Map<ClienteDto>(cliente);

            return clienteDto;
        }

        public async Task<int> ObterTotalDeRegistros()
        {
            var total = await this._serviceCliente.ObterTotalDeRegistros();
            return total;
        }

        public async Task<IEnumerable<ClienteDto>> ObterClientesComPaginacao(int page, int limit, string sort)
        {
            var clientes = await this._serviceCliente.ObterClientesComPaginacao(page, limit, sort);
            var clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

            return clientesDto;
        }
    }
}
