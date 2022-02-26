using Geti.Business.Models;
using System;
using System.Collections.Generic;

namespace Geti.Api.ViewModels
{
    public class EquipamentoViewModel
    {
        public Guid ColaboradorId { get; set; }

        public string Patrimonio { get; set; }

        public TipoEquipamento TipoEquipamento { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAquisicao { get; set; }

        public string NotaFiscal { get; set; }

        public StatusEquipamento StatusEquipamento { get; set; }

        public Colaborador Colaborador { get; set; }

        public List<string> Comentarios { get; set; }

        public IEnumerable<LicencaViewModel> Licencas { get; set; }
    }
}
