using Abigeapp.Domain.Fincas;
using System.Text.Json.Serialization;

namespace Abigeapp.Application.Fincas;

public record PerimetroDto
{
    public required Guid Id { get; init; }
    public required string Nombre { get; init; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required TipoPerimetro Tipo { get; init; }
    public required IEnumerable<CoordenadaDto> Coordenadas { get; init; }
}
