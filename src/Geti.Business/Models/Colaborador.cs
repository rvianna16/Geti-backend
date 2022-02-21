using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Geti.Business.Models
{
    public class Colaborador : Entity
    {       
        public string Nome { get; set; }  
        
        public string Email { get; set; }

        public IEnumerable<Equipamento> Equipamentos { get; set; }
    }
}
