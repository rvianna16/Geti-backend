using System;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Software
{
    public class SoftwareViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}
