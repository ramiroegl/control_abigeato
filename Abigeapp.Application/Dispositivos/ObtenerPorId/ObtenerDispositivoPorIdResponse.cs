using Abigeapp.Application.Fincas;

namespace Abigeapp.Application.Dispositivos.ObtenerPorId;

public record ObtenerDispositivoPorIdResponse : DispositivoDto
{
    public required PerimetroDto Perimetro { get; init; }
}