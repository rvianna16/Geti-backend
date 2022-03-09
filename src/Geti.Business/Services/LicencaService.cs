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
        private readonly IEquipamentoRepository _equipamentoRepository;
        public LicencaService(
            INotificador notificador,
            ILicencaRepository licencaRepository, IEquipamentoRepository equipamentoRepository) : base(notificador)
        {
            _licencaRepository = licencaRepository;
            _equipamentoRepository = equipamentoRepository;
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

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
    
