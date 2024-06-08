using Abigeapp.Domain.Dispositivos;
using MediatR;

namespace Abigeapp.Application.Dispositivos.ObtenerPorFinca;

public class DispositivosPorFincaHandler(IDispositivoTabla dispositivoTabla) : IRequestHandler<DispositivosPorFincaQuery, DispositivosPorFincaResponse>
{
    public async Task<DispositivosPorFincaResponse> Handle(DispositivosPorFincaQuery request, CancellationToken cancellationToken)
    {
        var obtenerDispositivosSpec = new ObtenerDispositivoSpec(request.FincaId, request.Pagina, request.Cantidad);
        var dispositivos = await dispositivoTabla.ListAsync(obtenerDispositivosSpec, cancellationToken);
        var total = await dispositivoTabla.CountAsync(obtenerDispositivosSpec, cancellationToken);

        return new DispositivosPorFincaResponse(dispositivos.Select(MapDispositivo), total);
    }

    private static DispositivoDto MapDispositivo(Dispositivo dispositivo)
    {
        return new DispositivoDto
        {
            Id = dispositivo.Id,
            Codigo = dispositivo.Codigo,
            Estado = dispositivo.Estado,
            Latitud = dispositivo.Latitud,
            Longitud = dispositivo.Longitud
        };
    }
}