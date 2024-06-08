namespace Abigeapp.Application.Fincas.ObtenerPorId;

public record ObtenerFincaPorIdResponse
{
    public required Guid Id { get; init; }
    public required string Nombre { get; init; }
    public required decimal Latitud { get; init; }
    public required decimal Longitud { get; init; }
    public required IEnumerable<PerimetroDto> Perimetros { get; init; }
}
