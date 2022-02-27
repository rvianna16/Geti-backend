using System.Collections.Generic;

namespace Geti.Api.ViewModels.Equipamento
{
    public class EquipamentoLicencasViewModel : EquipamentoViewModel
    {
        public IEnumerable<LicencaViewModel> Licencas { get; set; }
    }
}
