using Abigeapp.Application.Dispositivos;
using Abigeapp.Domain.Dispositivos;
using System.Text.Json.Serialization;

namespace Abigeapp.Application.Fincas;

public record AlertaDto
{
    public required Guid Id { get; set; }
    public required Guid DispositivoId { get; set; }
    public required DispositivoDto Dispositivo { get; set; }
    public required string Descripcion { get; set; }
    public required DateTimeOffset FechaCreacion { get; set; }
    public required decimal Latitud { get; set; }
    public required decimal Longitud { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required EstadoAlerta Estado { get; set; }
}