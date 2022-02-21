using Geti.Business.Interfaces;
using Geti.Business.Models;
using System;
using System.Threading.Tasks;

namespace Geti.Business.Services
{
    public class LicencaService : BaseService, ILicencaService
    {

        public LicencaService(INotificador notificador) : base(notificador) { }

        public Task Adicionar(Licenca licenca)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Licenca licenca)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
    
