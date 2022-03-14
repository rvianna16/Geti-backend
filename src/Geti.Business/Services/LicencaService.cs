using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Business.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Geti.Business.Services
{
    public class LicencaService : BaseService, ILicencaService
    {
        private readonly ILicencaRepository _licencaRepository;
        private readonly IEquipamentoLicencaService _equipamentoLicencaService;
        public LicencaService(
            INotificador notificador,
            ILicencaRepository licencaRepository,            
            IEquipamentoLicencaService equipamentoLicencaService) : base(notificador)
        {
            _licencaRepository = licencaRepository;
            _equipamentoLicencaService = equipamentoLicencaService;
        }

        public async Task Adicionar(Licenca licenca)
        {
            if (!ExecutarValidacao(new LicencaValidation(), licenca)) return;

            if (_licencaRepository.Buscar(f => f.Nome == licenca.Nome).Result.Any())
            {
                Notificar("Já existe uma licença com este nome cadastrada");
                return;
            }           

            await _licencaRepository.Adicionar(licenca);
        }

        public async Task Atualizar(Licenca licenca)
        {
            if (!ExecutarValidacao(new LicencaValidation(), licenca)) return;

            await _licencaRepository.Atualizar(licenca);
        }

        public async Task Remover(Guid id)
        {
            var licenca = _licencaRepository.ObterLicencaEquipamentos(id);

            foreach (var licencaVinculada in licenca.Result.Equipamentos)
            {
                await _equipamentoLicencaService.Remover(licencaVinculada.Id);
            }

            await _licencaRepository.Remover(id);
        }
    }
}
    
