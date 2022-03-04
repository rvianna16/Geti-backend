using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Colaborador
{
    public class ColaboradorEquipamentosViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public IEnumerable<EquipamentoViewModel> Equipamentos { get; set; }
    }
}
