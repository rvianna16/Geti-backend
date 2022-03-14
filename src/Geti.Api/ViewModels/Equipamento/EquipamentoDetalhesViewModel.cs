using Geti.Api.ViewModels.Licenca;
using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Equipamento
{
    public class EquipamentoDetalhesViewModel
    {

        [Key]
        public Guid Id { get; set; }

        public Guid ColaboradorId { get; set; }

        public string Patrimonio { get; set; }

        public TipoEquipamento TipoEquipamento { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataAquisicao { get; set; }

        public string NomeColaborador { get; set; }

        public string NotaFiscal { get; set; }

        public string Modelo { get; set; }

        public string Armazenamento { get; set; }

        public string Memoria { get; set; }

        public string Processador { get; set; }

        public string IP { get; set; }

        public StatusEquipamento StatusEquipamento { get; set; }

        public IEnumerable<LicencaEquipamentoBasicoViewModel> Licencas { get; set; }

        public IEnumerable<ComentarioViewModel> Comentarios { get; set; }

    }
}
