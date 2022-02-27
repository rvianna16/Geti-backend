using Geti.Api.ViewModels.Equipamento;
using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels
{
    public class EquipamentoViewModel
    { 

        [Key]
        public Guid Id { get; set; }

        public Guid ColaboradorId { get; set; }

        public string Patrimonio { get; set; }

        public TipoEquipamento TipoEquipamento { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAquisicao { get; set; }

        public string NomeColaborador { get; set; }

        public string NotaFiscal { get; set; }

        public StatusEquipamento StatusEquipamento { get; set; }       

        public IEnumerable<ComentarioViewModel> Comentarios { get; set; }
        
    }
}
