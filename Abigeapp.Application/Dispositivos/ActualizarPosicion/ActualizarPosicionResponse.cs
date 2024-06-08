using Abigeapp.Domain.Dispositivos;
using System.Text.Json.Serialization;

namespace Abigeapp.Application.Dispositivos.ActualizarPosicion;

public record ActualizarPosicionResponse
{
    public required Guid Id { get; init; }
    public required decimal Latitud { get; init; }
    public required decimal Longitud { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required EstadoDispositivo Estado { get; init; }
}
