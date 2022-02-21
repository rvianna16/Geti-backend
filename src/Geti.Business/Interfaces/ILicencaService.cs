using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface ILicencaService
    {
        Task Adicionar(Licenca licenca);
        Task Atualizar(Licenca licenca);
        Task Remover(Guid id);

    }
}
