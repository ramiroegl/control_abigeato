using Abigeapp.Application.Dispositivos.PorFinca;
using Abigeapp.Domain.Dispositivos;
using MediatR;

namespace Abigeapp.Application.Dispositivos;

public record DispositivosPorFincaQuery : IRequest<DispositivosPorFincaResponse>
{
    public required Guid FincaId { get; init; }
    public required int Pagina { get; init; }
    public required int Cantidad { get; init; }
}

public class DispositivosPorFincaHandler(IDispositivoTabla dispositivoTabla) : IRequestHandler<DispositivosPorFincaQuery, DispositivosPorFincaResponse>
{
    public async Task<DispositivosPorFincaResponse> Handle(DispositivosPorFincaQuery request, CancellationToken cancellationToken)
    {
        var obtenerDispositivosSpec = new ObtenerDispositivoSpec(request.FincaId, request.Pagina, request.Cantidad);
        var dispositivos = await dispositivoTabla.ListAsync(obtenerDispositivosSpec, cancellationToken);
        var total = await dispositivoTabla.CountAsync(obtenerDispositivosSpec, cancellationToken);

        return new DispositivosPorFincaResponse(dispositivos.Select(dispositivo => new DispositivoDto
        {
            Id = dispositivo.Id,
            Codigo = dispositivo.Codigo,
            Estado = dispositivo.Estado,
            Latitud = dispositivo.Latitud,
            Longitud = dispositivo.Longitud
        }), total);
    }
}