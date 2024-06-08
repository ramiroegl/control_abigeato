using MediatR;

namespace Abigeapp.Application.Dispositivos.ObtenerPorId;

public record ObtenerDispositivoPorIdQuery : IRequest<ObtenerDispositivoPorIdResponse>
{
    public required Guid Id { get; init; }
}
