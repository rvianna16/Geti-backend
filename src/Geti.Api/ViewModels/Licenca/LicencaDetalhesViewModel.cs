using Geti.Api.ViewModels.Equipamento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels
{
    public class LicencaDetalhesViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Chave { get; set; }

        public string Software { get; set; }

        public int Quantidade { get; set; }

        public int Disponivel { get; set; }

        public DateTime? DataExpiracao { get; set; }

        public ICollection<EquipamentoLicencaBasicoViewModel> Equipamentos { get; set; }

        public bool Ativo { get; set; }
    }
}
