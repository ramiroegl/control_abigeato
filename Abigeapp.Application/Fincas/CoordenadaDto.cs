namespace Abigeapp.Application.Fincas;

public record CoordenadaDto
{
    public required int Orden { get; init; }
    public required decimal Latitud { get; init; }
    public required decimal Longitud { get; init; }
}
