using Geti.Api.ViewModels.Licenca;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Software
{
    public class SoftwareDetalhesViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public IEnumerable<LicencaEquipamentoBasicoViewModel> Licencas { get; set; }
    }
}
