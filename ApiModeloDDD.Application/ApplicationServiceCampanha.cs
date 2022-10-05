using AutoMapper;
using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Application.Interfaces;
using ApiModeloDDD.Domain.Core.Interfaces.Services;
using ApiModeloDDD.Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Application
{
    public class ApplicationServiceCampanha : IApplicationServiceCampanha
    {
        private readonly IServiceCampanha _serviceCampanha;
        private readonly IMapper _mapper;

        public ApplicationServiceCampanha(IServiceCampanha serviceCampanha,
            IMapper mapper)
        {
            this._serviceCampanha = serviceCampanha;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<CampanhaDto>> GetAll()
        {
            var campanhas = await this._serviceCampanha.GetAll();
            var campanhasDto = _mapper.Map<IEnumerable<CampanhaDto>>(campanhas);

            return campanhasDto;
        }

        public async Task<CampanhaDto> GetById(int id)
        {
            var campanha = await this._serviceCampanha.GetById(id);
            var campanhaDto = _mapper.Map<CampanhaDto>(campanha);

            return campanhaDto;
        }

        public async Task<int> ObterTotalDeRegistros(int? clienteId = null)
        {
            var total = await this._serviceCampanha.ObterTotalDeRegistros(clienteId);
            return total;
        }

        public async Task<IEnumerable<CampanhaDto>> ObterCampanhasComPaginacao(int page, int limit, string sort)
        {
            var campanhas = await this._serviceCampanha.ObterCampanhasComPaginacao(page, limit, sort);
            var campanhasDto = _mapper.Map<IEnumerable<CampanhaDto>>(campanhas);

            return campanhasDto;
        }

        public async Task<IEnumerable<CampanhaDto>> ObterCampanhasPorClienteIdComPaginacao(int clienteId, int page, int limit, string sort)
        {
            var campanhas = await this._serviceCampanha.ObterCampanhasPorClienteIdComPaginacao(clienteId, page, limit, sort);
            var campanhasDto = _mapper.Map<IEnumerable<CampanhaDto>>(campanhas);

            return campanhasDto;
        }
    }
}