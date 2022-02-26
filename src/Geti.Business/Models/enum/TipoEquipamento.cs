using System.Text.Json.Serialization;

namespace Geti.Business.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoEquipamento
    {
        Desktop,
        Notebook,
        Servidor,
        Monitor,
        Impressora,

    }
}
