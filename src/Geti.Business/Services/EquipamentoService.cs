using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Business.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Geti.Business.Services
{
    public class EquipamentoService : BaseService, IEquipamentoService
    {
        private readonly IEquipamentoRepository _equipamentoRepository;
        private readonly IComentarioRepository _comentarioRepository;

        public EquipamentoService(
            IEquipamentoRepository equipamentoRepository,
            IComentarioRepository comentarioRepository,
            INotificador notificador
            ) : base(notificador)
        {
            _equipamentoRepository = equipamentoRepository;
            _comentarioRepository = comentarioRepository;
        }

        public async Task Adicionar(Equipamento equipamento)
        {
            if (!ExecutarValidacao(new EquipamentoValidation(), equipamento)) return;

            if (_equipamentoRepository.Buscar(f => f.Patrimonio == equipamento.Patrimonio).Result.Any())
            {
                Notificar("Já existe um equipamento com este patrimônio cadastrado.");
                return;
            }

            await _equipamentoRepository.Adicionar(equipamento);          

        }      

        public async Task Atualizar(Equipamento equipamento)
        {
            if (!ExecutarValidacao(new EquipamentoValidation(), equipamento)) return;

            await _equipamentoRepository.Atualizar(equipamento);
        }

        public Task AtualizarLicenca(Licenca licenca)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Guid id)
        {
            var equipamento = _equipamentoRepository.ObterEquipamentoDetalhes(id);

            foreach (var comentario in equipamento.Result.Comentarios)
            {
                await _comentarioRepository.Remover(comentario.Id);
            }

            await _equipamentoRepository.Remover(id);
        }
    }
}
