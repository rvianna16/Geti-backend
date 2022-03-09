using System;

namespace Geti.Business.Models
{
    public class EquipamentoLicenca : Entity
    {
        public Guid EquipamentoId { get; set; }
        public virtual Equipamento Equipamento { get; set; }

        public Guid LicencaId { get; set; }
        public virtual Licenca Licenca { get; set; }
    }
}
