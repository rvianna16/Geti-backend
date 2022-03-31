using AutoMapper;
using Geti.Api.ViewModels;
using Geti.Api.ViewModels.Equipamento;
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
        private readonly IComentarioService _comentarioService;
        private readonly IComentarioRepository _comentarioRepository;
        private readonly IMapper _mapper;
        public EquipamentosController(
            IEquipamentoRepository equipamentoRepository,
            IEquipamentoService equipamentoService,
            IComentarioRepository comentarioRepository,
            IComentarioService comentarioService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _equipamentoRepository = equipamentoRepository;
            _equipamentoService = equipamentoService;
            _comentarioRepository = comentarioRepository;
            _comentarioService = comentarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipamentoViewModel>>> ObterEquipamentos(string filtro)
        {
            var equipamentos = _mapper.Map<IEnumerable<EquipamentoViewModel>>(await _equipamentoRepository.ObterEquipamentosColaboradores(filtro));
            return CustomResponse(equipamentos);
        }

        [HttpGet("{id}/detalhes")]
        public async Task<ActionResult<EquipamentoDetalhesViewModel>> ObterEquipamentoPorId(Guid id)
        {
            var equipamentoViewModel = await ObterEquipamentoDetalhes(id);

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

        [HttpPost("{id}/comentario")]
        public async Task<ActionResult<ComentarioViewModel>> AdicionarComentario(ComentarioViewModel comentarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _comentarioService.Adicionar(_mapper.Map<Comentario>(comentarioViewModel));

            return CustomResponse(comentarioViewModel);
        }

        [HttpDelete("comentario/{id}")]
        public async Task<ActionResult<ComentarioViewModel>> ExcluirComentario(Guid id)
        {
            var comentario = await ObterComentario(id);

            if (comentario == null) return NotFound();

            await _comentarioService.Remover(id);

            return CustomResponse();
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
            return _mapper.Map<EquipamentoViewModel>(await _equipamentoRepository.ObterEquipamentoColaborador(id));
           
        }

        private async Task<EquipamentoDetalhesViewModel> ObterEquipamentoDetalhes(Guid id)
        {
            return _mapper.Map<EquipamentoDetalhesViewModel>(await _equipamentoRepository.ObterEquipamentoDetalhes(id));
        }

        private async Task<ComentarioViewModel> ObterComentario(Guid id)
        {
            return _mapper.Map<ComentarioViewModel>(await _comentarioRepository.ObterComentario(id));
        }

    }
}
