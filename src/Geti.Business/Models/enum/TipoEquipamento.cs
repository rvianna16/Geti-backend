using System.Text.Json.Serialization;

namespace Geti.Business.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoEquipamento
    {
        Desktop = 1,
        Notebook = 2,
        Servidor = 3,
        Monitor = 4,
        Impressora = 5,

    }
}
