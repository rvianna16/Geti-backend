using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Business.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Services
{
    public class SoftwareService : BaseService, ISoftwareService
    {
        private readonly ISoftwareRepository _softwareRepository;

        public SoftwareService(
            INotificador notificador,
            ISoftwareRepository softwareRepository) : base(notificador)
        {
            _softwareRepository = softwareRepository;
        }

        public async Task Adicionar(Software software)
        {
            if (!ExecutarValidacao(new SoftwareValidation(), software)) return;

            if (_softwareRepository.Buscar(f => f.Nome == software.Nome).Result.Any())
            {
                Notificar("Já existe um software com este nome cadastrado");
                return;
            }

            await _softwareRepository.Adicionar(software);
        }

        public async Task Atualizar(Software software)
        {
            if (!ExecutarValidacao(new SoftwareValidation(), software)) return;           

            await _softwareRepository.Atualizar(software);
        }

        public async Task Remover(Guid id)
        {
            var software = _softwareRepository.ObterSoftwareLicencas(id);

            if (software.Result.Licencas.Any())
            {
                Notificar("Não é possível excluir este software, pois ele possui licenças vinculadas a ele.");
                return;
            }
            await _softwareRepository.Remover(id);
        }
    }
}
