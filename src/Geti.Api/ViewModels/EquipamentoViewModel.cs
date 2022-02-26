using Geti.Business.Models;
using System;
using System.Collections.Generic;

namespace Geti.Api.ViewModels
{
    public class EquipamentoViewModel : Entity
    {
        public Guid ColaboradorId { get; set; }

        public string Patrimonio { get; set; }

        public TipoEquipamento TipoEquipamento { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAquisicao { get; set; }

        public string NomeColaborador { get; set; }

        public string NotaFiscal { get; set; }

        public StatusEquipamento StatusEquipamento { get; set; }       

        public string Comentario { get; set; }

        public IEnumerable<LicencaViewModel> Licencas { get; set; }
    }
}
