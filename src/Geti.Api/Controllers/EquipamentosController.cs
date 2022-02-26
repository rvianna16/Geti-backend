using AutoMapper;
using Geti.Api.ViewModels;
using Geti.Business.Interfaces;
using Geti.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geti.Api.Controllers
{
    [Route("api/equipamentos")]
    public class EquipamentosController : MainController
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IEquipamentoService _equipamentoService;
        private readonly IMapper _mapper;
        public EquipamentosController(
            IEquipamentoRepository equipamentoRepository,
            IEquipamentoService equipamentoService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _equipamentoRepository = equipamentoRepository;
            _equipamentoService = equipamentoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipamentoViewModel>>> ObterEquipamentos()
        {
            var equipamentos = _mapper.Map<IEnumerable<EquipamentoViewModel>>(await _equipamentoRepository.ObterTodos());
            return CustomResponse(equipamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipamentoViewModel>> ObterEquipamentoPorId(Guid id)
        {
            var equipamentoViewModel = _mapper.Map<EquipamentoViewModel>(await _equipamentoRepository.ObterPorId(id));
            if (equipamentoViewModel == null) return NotFound();

            return CustomResponse(equipamentoViewModel);
        }

        [HttpPost]
        public async Task<ActionResult<EquipamentoViewModel>> AdicionarEquipamento(EquipamentoViewModel equipamentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _equipamentoService.Adicionar(_mapper.Map<Equipamento>(equipamentoViewModel));

            return CustomResponse(equipamentoViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EquipamentoViewModel>> AtualizarEquipamento(Guid id, EquipamentoViewModel equipamentoViewModel)
        {
            if (id != equipamentoViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _equipamentoService.Atualizar(_mapper.Map<Equipamento>(equipamentoViewModel));

            return CustomResponse(equipamentoViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EquipamentoViewModel>> ExcluirEquipamento(Guid id)
        {
            var equipamento = await ObterEquipamento(id);

            if (equipamento == null) return NotFound();

            await _equipamentoService.Remover(id);

            return CustomResponse();
        }


        private async Task<EquipamentoViewModel> ObterEquipamento(Guid id)
        {
            return _mapper.Map<EquipamentoViewModel>(await _equipamentoRepository.ObterEquipamentoLicencas(id));
           
        }

    }
}
