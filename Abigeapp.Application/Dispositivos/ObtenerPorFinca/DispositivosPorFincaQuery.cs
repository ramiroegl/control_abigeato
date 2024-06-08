using MediatR;

namespace Abigeapp.Application.Dispositivos.ObtenerPorFinca;

public record DispositivosPorFincaQuery : IRequest<DispositivosPorFincaResponse>
{
    public required Guid FincaId { get; init; }
    public required int Pagina { get; init; }
    public required int Cantidad { get; init; }
}
