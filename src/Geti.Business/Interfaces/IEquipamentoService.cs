using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Interfaces
{
    public interface IEquipamentoService
    {
        Task<bool> Adicionar(Equipamento equipamento);

        Task Atualizar(Equipamento equipamento);

        Task Remover(Guid id);

        Task AtualizarLicenca(Licenca licenca);
    }
}
