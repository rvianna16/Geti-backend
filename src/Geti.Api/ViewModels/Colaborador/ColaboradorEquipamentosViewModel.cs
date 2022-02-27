using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Colaborador
{
    public class ColaboradorEquipamentosViewModel : ColaboradorViewModel
    {
        public IEnumerable<EquipamentoViewModel> Equipamentos { get; set; }
    }
}
