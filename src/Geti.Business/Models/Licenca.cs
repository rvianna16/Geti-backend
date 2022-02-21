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

        public DateTime DataExpiracao { get; set; }

        public IEnumerable<Equipamento> Equipamentos { get; set; }

        public bool Ativo { get; set; }
    }
}
