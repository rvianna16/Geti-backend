using AutoMapper;
using Geti.Api.ViewModels.Software;
using Geti.Business.Interfaces;
using Geti.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geti.Api.Controllers
{
    [Authorize]
    [Route("api/softwares")]
    public class SoftwaresController : MainController
    {
        private readonly ISoftwareRepository _softwareRepository;
        private readonly ISoftwareService _softwareService;
        private readonly IMapper _mapper;
        public SoftwaresController(
            INotificador notificador,
            ISoftwareRepository softwareRepository,
            ISoftwareService softwareService,
            IMapper mapper) : base(notificador)
        {
            _softwareRepository = softwareRepository;
            _mapper = mapper;
            _softwareService = softwareService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SoftwareViewModel>>> ObterSoftwares(string filtro)
        {
            var softwares = _mapper.Map<IEnumerable<SoftwareViewModel>>(await _softwareRepository.ObterSoftwares(filtro));

            return CustomResponse(softwares);
        }

        [HttpGet("{id}/detalhes")]
        public async Task<ActionResult<SoftwareDetalhesViewModel>> ObterSoftwarePorId(Guid id)
        {
            var softwareViewModel = _mapper.Map<SoftwareDetalhesViewModel>(await ObterSoftwareDetalhes(id));

            if (softwareViewModel == null) return NotFound();

            return CustomResponse(softwareViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<SoftwareViewModel>> AdicionarSoftware(SoftwareViewModel softwareViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _softwareService.Adicionar(_mapper.Map<Software>(softwareViewModel));

            return CustomResponse(softwareViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SoftwareViewModel>> AtualizarSoftware(Guid id, SoftwareViewModel softwareViewModel)
        {
            if (id != softwareViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _softwareService.Atualizar(_mapper.Map<Software>(softwareViewModel));

            return CustomResponse(softwareViewModel);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SoftwareViewModel>> ExcluirSoftware(Guid id)
        {
            var software = await ObterSoftwareDetalhes(id);

            if (software == null) return NotFound();

            await _softwareService.Remover(id);

            return CustomResponse();
        }

        private async Task<SoftwareDetalhesViewModel> ObterSoftwareDetalhes(Guid id)
        {
            return _mapper.Map<SoftwareDetalhesViewModel>(await _softwareRepository.ObterSoftwareLicencas(id));
        }

    }
}
