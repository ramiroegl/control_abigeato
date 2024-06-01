using MediatR;

namespace Abigeapp.Application.Dispositivos.ActualizarPosicion;

public record ActualizarPosicionCommand : IRequest<ActualizarPosicionResponse>
{
    public Guid Id { get; init; }
    public decimal Latitud { get; init; }
    public decimal Longitud { get; init; }
}
