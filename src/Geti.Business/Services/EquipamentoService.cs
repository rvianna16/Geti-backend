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

        public EquipamentoService(
            IEquipamentoRepository equipamentoRepository,
            INotificador notificador
            ) : base(notificador)
        {
            _equipamentoRepository = equipamentoRepository;
        }

        public async Task<bool> Adicionar(Equipamento equipamento)
        {
            if (!ExecutarValidacao(new EquipamentoValidation(), equipamento)) return false;

            if (_equipamentoRepository.Buscar(f => f.Patrimonio == equipamento.Patrimonio).Result.Any())
            {
                Notificar("Já existe um equipamento com este patrimônio cadastrado.");
                return false;
            }

            await _equipamentoRepository.Adicionar(equipamento);
            return true;

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
            await _equipamentoRepository.Remover(id);
        }
    }
}
