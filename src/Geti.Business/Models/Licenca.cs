using System;
using System.Collections.Generic;

namespace Geti.Business.Models
{
    public class Licenca : Entity
    {
        public string Nome { get; set; }

        public string Chave { get; set; }

        public string Software { get; set; }

        public int Quantidade { get; set; }

        public int Disponivel { get; set; }

        public DateTime DataExpiracao { get; set; }

        public ICollection<EquipamentoLicenca> Equipamentos { get; set; }

        public bool Ativo { get; set; }

    }
}
