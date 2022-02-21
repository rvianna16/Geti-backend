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
    [Route("api/[controller]")]
    public class ColaboradoresController : MainController
    {

        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IColaboradorService _colaboradorService;
        private readonly IMapper _mapper;

        public ColaboradoresController(
            IColaboradorRepository colaboradorRepository,
            IColaboradorService colaboradorService,
            IMapper mapper)
        {
            _colaboradorRepository = colaboradorRepository;
            _colaboradorService = colaboradorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColaboradorViewModel>>> ObterColaboradores()
        {
            var colaborador = _mapper.Map<IEnumerable<ColaboradorViewModel>>(await _colaboradorRepository.ObterTodos());

            return Ok(colaborador);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColaboradorViewModel>> ObterColaborador(Guid id)
        {
            var colaborador = _mapper.Map<ColaboradorViewModel>(await _colaboradorRepository.ObterPorId(id));

            if (colaborador == null) return NotFound();
            return Ok(colaborador);
        }

        [HttpPost]
        public async Task<ActionResult<ColaboradorViewModel>> AdicionarColaborador(ColaboradorViewModel colaboradorViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var colaborador = _mapper.Map<Colaborador>(colaboradorViewModel);

            var result = await _colaboradorService.Adicionar(colaborador);

            if (!result) return BadRequest();

            return Ok(colaborador);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ColaboradorViewModel>> AtualizarColaborador(Guid id, ColaboradorViewModel colaboradorViewModel)
        {
            if (id != colaboradorViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var colaborador = _mapper.Map<Colaborador>(colaboradorViewModel);

            await _colaboradorService.Atualizar(colaborador);            

            return Ok(colaborador);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ColaboradorViewModel>> ExcluirColaborador(Guid id)
        {
            var colaborador = await ObterFornecedor(id);

            if (colaborador == null) return NotFound();

            await _colaboradorService.Remover(id);

            return Ok(colaborador);
        }

        public async Task<ColaboradorViewModel> ObterFornecedor(Guid id)
        {
            return _mapper.Map<ColaboradorViewModel>(await _colaboradorRepository.ObterColaborador(id));
        }


    }
}
