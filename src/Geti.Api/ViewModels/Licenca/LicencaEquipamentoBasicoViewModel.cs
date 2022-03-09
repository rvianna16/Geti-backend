using System;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Licenca
{
    public class LicencaEquipamentoBasicoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Chave { get; set; }

        public string Software { get; set; }
    }
}
