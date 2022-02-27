using System;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Equipamento
{
    public class ComentarioViewModel
    {
        [Key]
        public Guid Id { get; set; }        

        public Guid EquipamentoId { get; set; }

        public DateTime DataComentario { get; set; }

        public string Descricao { get; set; }
    }
}
