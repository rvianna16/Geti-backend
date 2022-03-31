using AutoMapper;
using Geti.Api.ViewModels;
using Geti.Api.ViewModels.Colaborador;
using Geti.Business.Interfaces;
using Geti.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geti.Api.Controllers
{
    [Route("api/colaboradores")]
    public class ColaboradoresController : MainController
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IColaboradorService _colaboradorService;
        private readonly IMapper _mapper;

        public ColaboradoresController(
            IColaboradorRepository colaboradorRepository,
            IColaboradorService colaboradorService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _colaboradorRepository = colaboradorRepository;
            _colaboradorService = colaboradorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColaboradorViewModel>>> ObterColaboradores(string filtro)
        {
            var colaboradores = _mapper.Map<IEnumerable<ColaboradorViewModel>>(await _colaboradorRepository.ObterTodosColaboradores(filtro));

            return CustomResponse(colaboradores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColaboradorViewModel>> ObterColaborador(Guid id)
        {
            var colaborador = _mapper.Map<ColaboradorViewModel>(await _colaboradorRepository.ObterPorId(id));

            if (colaborador == null)
            {
                NotificarErro("Não foi possível encontrar um colaborador com este id");
                return CustomResponse();
            };

            return CustomResponse(colaborador);
        }

        [HttpGet("{id}/equipamentos")]
        public async Task<ActionResult<ColaboradorEquipamentosViewModel>> ObterColaboradorListaEquipamentos(Guid id)
        {
            var colaborador = await ObterColaboradorEquipamentos(id);

            if (colaborador == null) return NotFound();

            return CustomResponse(colaborador);
        }

        [HttpPost]
        public async Task<ActionResult<ColaboradorViewModel>> AdicionarColaborador(ColaboradorViewModel colaboradorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _colaboradorService.Adicionar(_mapper.Map<Colaborador>(colaboradorViewModel));

            return CustomResponse(colaboradorViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ColaboradorViewModel>> AtualizarColaborador(Guid id, ColaboradorViewModel colaboradorViewModel)
        {
            if (id != colaboradorViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _colaboradorService.Atualizar(_mapper.Map<Colaborador>(colaboradorViewModel));

            return CustomResponse(colaboradorViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ColaboradorViewModel>> ExcluirColaborador(Guid id)
        {
            var colaborador = await ObterColaboradorEquipamentos(id);

            if (colaborador == null) return NotFound();            

            await _colaboradorService.Remover(id);

            return CustomResponse();
        }
                
        private async Task<ColaboradorEquipamentosViewModel> ObterColaboradorEquipamentos(Guid id)
        {
            return _mapper.Map<ColaboradorEquipamentosViewModel>(await _colaboradorRepository.ObterColaboradorEquipamentos(id));
        }
    }    
}
