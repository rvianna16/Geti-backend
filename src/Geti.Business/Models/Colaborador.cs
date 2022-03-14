using System.Collections.Generic;

namespace Geti.Business.Models
{
    public class Colaborador : Entity
    {       
        public string Nome { get; set; }  
        
        public string Email { get; set; }

        public IEnumerable<Equipamento> Equipamentos { get; set; }

    }
}
