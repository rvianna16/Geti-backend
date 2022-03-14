using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Models
{
    public class Software : Entity
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public IEnumerable<Licenca> Licencas { get; set; }
    }
}
