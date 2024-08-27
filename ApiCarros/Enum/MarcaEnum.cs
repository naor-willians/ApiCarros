using System.Text.Json.Serialization;

namespace ApiCarros.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MarcaEnum
    {
        Ford,
        Chevrolet,
        Fiat,
        Ferrari
    }
}
