

using System.Text.Json.Serialization;

namespace Geti.Business.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEquipamento
    {
        Disponivel,
        EmUso,
        Reservado,
        EmDescarte,
        Descartado
    }
}