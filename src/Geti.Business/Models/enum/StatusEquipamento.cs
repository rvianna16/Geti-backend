

using System.Text.Json.Serialization;

namespace Geti.Business.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEquipamento
    {
        Disponivel = 1,
        EmUso = 2,
        Reservado = 3,
        EmDescarte = 4,
        Descartado = 5
    }
}