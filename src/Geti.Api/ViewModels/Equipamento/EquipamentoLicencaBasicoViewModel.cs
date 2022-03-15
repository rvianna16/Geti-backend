using Geti.Business.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Equipamento
{
    public class EquipamentoLicencaBasicoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Patrimonio { get; set; }

        public TipoEquipamento TipoEquipamento { get; set; }

        public StatusEquipamento StatusEquipamento { get; set; }

    }
}
