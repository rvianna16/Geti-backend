using System;
using System.Collections.Generic;

namespace Geti.Business.Models
{
    public class Equipamento : Entity
    {           
        public Guid ColaboradorId { get; set; }

        public string Patrimonio { get; set; }

        public TipoEquipamento TipoEquipamento { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAquisicao { get; set; }

        public string NotaFiscal { get; set; }

        public string Modelo { get; set; }

        public string Armazenamento { get; set; }

        public string Processador { get; set; }

        public string IP { get; set; }

        public StatusEquipamento StatusEquipamento { get; set; }

        public IEnumerable<Comentario> Comentarios { get; set; }

        public IEnumerable<Licenca> Licencas { get; set; }

        public Colaborador Colaborador { get; set; }

    }
}
