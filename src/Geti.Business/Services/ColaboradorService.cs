using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Business.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace Geti.Business.Services
{
    public class ColaboradorService : BaseService, IColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(
            IColaboradorRepository colaboradorRepository,
            INotificador notificador
            ) : base(notificador)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<bool> Adicionar(Colaborador colaborador)
        {
            if (!ExecutarValidacao(new ColaboradorValidation(), colaborador)) return false;

            if (_colaboradorRepository.Buscar(f => f.Email == colaborador.Email).Result.Any())
            {
                Notificar("Já existe um colaborador com este e-mail cadastrado.");
                return false;
            }

            await _colaboradorRepository.Adicionar(colaborador);
            return true;
            
        }

        public async Task Atualizar(Colaborador colaborador)
        {
            if (!ExecutarValidacao(new ColaboradorValidation(), colaborador)) return;

            await _colaboradorRepository.Atualizar(colaborador);
        }            

        public async Task Remover(Guid id)
        {
            await _colaboradorRepository.Remover(id);
        }

        public void Dispose()
        {
            _colaboradorRepository?.Dispose();
        }
    }
}
    
