using AutoMapper;
using Geti.Api.ViewModels;
using Geti.Api.ViewModels.Licenca;
using Geti.Business.Interfaces;
using Geti.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geti.Api.Controllers
{
    [Route("api/licencas")]
    public class LicencasController : MainController
    {
        private readonly ILicencaRepository _licencaRepository;
        private readonly ILicencaService _licencaService;
        private readonly IEquipamentoLicencaRepository _equipamentoLicencaRepository;
        private readonly IEquipamentoLicencaService _equipamentoLicencaService;
        private readonly IMapper _mapper;
        public LicencasController(
            INotificador notificador,
            ILicencaRepository licencaRepository,
            IMapper mapper,
            ILicencaService licencaService, 
            IEquipamentoLicencaRepository equipamentoRepository, 
            IEquipamentoLicencaService equipamentoService) : base(notificador)
        {
            _licencaRepository = licencaRepository;
            _mapper = mapper;
            _licencaService = licencaService;
            _equipamentoLicencaRepository = equipamentoRepository;
            _equipamentoLicencaService = equipamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicencaViewModel>>> ObterLicencas()
        {
            var licencas = _mapper.Map<IEnumerable<LicencaViewModel>>(await _licencaRepository.ObterTodos());
            return CustomResponse(licencas);
        }

        [HttpGet("{id}/detalhes")]
        public async Task<ActionResult<LicencaDetalhesViewModel>> ObterLicencaPorId(Guid id)
        {
            var licencaViewModel = _mapper.Map<LicencaDetalhesViewModel>(await ObterLicencaDetalhes(id));

            if (licencaViewModel == null) return NotFound();

            return CustomResponse(licencaViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<AddEquipamentoLicencaViewModel>> AdicionarLicenca(LicencaViewModel licencaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _licencaRepository.Adicionar(_mapper.Map<Licenca>(licencaViewModel));

            return CustomResponse(licencaViewModel);
        }

        [HttpPost("vincular/equipamento")]
        public async Task<ActionResult<AddEquipamentoLicencaViewModel>> VincularLicenca(AddEquipamentoLicencaViewModel licencaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _equipamentoLicencaService.Adicionar(_mapper.Map<EquipamentoLicenca>(licencaViewModel));

            return CustomResponse(licencaViewModel);
        }

        [HttpDelete("vincular/equipamento")]
        public async Task<ActionResult<AddEquipamentoLicencaViewModel>> RemoverLicencaVinculada(Guid id)
        {
            var licenca = await ObterLicencaVinculada(id);

            if (licenca == null) return NotFound();

            await _equipamentoLicencaService.Remover(id);

            return CustomResponse();
        }


        private async Task<EquipamentoLicenca> ObterLicencaVinculada(Guid id)
        {
            return _mapper.Map<EquipamentoLicenca>(await _equipamentoLicencaRepository.ObterLicencaVinculada(id));
        }

        private async Task<LicencaDetalhesViewModel> ObterLicencaDetalhes(Guid id)
        {
            return _mapper.Map<LicencaDetalhesViewModel>(await _licencaRepository.ObterLicencaEquipamentos(id));
        }


    }
}
