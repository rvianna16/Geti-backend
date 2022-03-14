using System;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Licenca
{
    public class LicencaViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Chave { get; set; }

        public Guid SoftwareId { get; set; }

        public string Software { get; set; }

        public int Quantidade { get; set; }

        public int Disponivel { get; set; }

        public DateTime? DataExpiracao { get; set; }

        public bool Ativo { get; set; }
    }
}
