using Geti.Business.Interfaces;
using Geti.Business.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Geti.Business.Services
{
    public class EquipamentoLicencaService : BaseService, IEquipamentoLicencaService
    {
        private readonly IEquipamentoLicencaRepository _equipamentoLicencaRepository;
        public EquipamentoLicencaService(INotificador notificador, IEquipamentoLicencaRepository equamentoLicencaRepository) : base(notificador)
        {
            _equipamentoLicencaRepository = equamentoLicencaRepository;
        }
        public async Task Adicionar(EquipamentoLicenca equipamentoLicenca)
        {

            if (_equipamentoLicencaRepository.Buscar(f => f.EquipamentoId == equipamentoLicenca.EquipamentoId).Result.Any() &&
                _equipamentoLicencaRepository.Buscar(f => f.LicencaId == equipamentoLicenca.LicencaId).Result.Any())
            {
                Notificar("Esta licença ja está vinculada a este equipamento");
                return;
            }
            await _equipamentoLicencaRepository.Adicionar(equipamentoLicenca);
        }

        public async Task Remover(Guid id)
        {
            await _equipamentoLicencaRepository.Remover(id);

        }

        public void Dispose()
        {
            _equipamentoLicencaRepository?.Dispose();
        }
    }
}
