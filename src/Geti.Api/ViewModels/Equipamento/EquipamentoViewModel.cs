using Geti.Business.Models;
using System;
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

        public DateTime? DataAquisicao { get; set; }

        public string NomeColaborador { get; set; }

        public string NotaFiscal { get; set; }

        public string Modelo { get; set; }

        public string Armazenamento { get; set; }

        public string Memoria { get; set; }

        public string Processador { get; set; }

        public string IP { get; set; }

        public StatusEquipamento StatusEquipamento { get; set; }    
        
    }
}
