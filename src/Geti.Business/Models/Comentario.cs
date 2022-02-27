using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Models
{
    public class Comentario : Entity
    {
        public Guid EquipamentoId { get; set; }

        public DateTime DataComentario { get; set; }

        public string Descricao { get; set; }        

        public Equipamento Equipamento { get; set; }

    }
}
