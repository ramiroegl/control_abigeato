using Abigeapp.Domain.Compartido;
using Abigeapp.Domain.Dispositivos;
using MediatR;

namespace Abigeapp.Application.Dispositivos.ActualizarPosicion;

public class ActualizarPosicionHandler(IDispositivoTabla dispositivoTabla, IAlertaTabla alertaTabla) : IRequestHandler<ActualizarPosicionCommand, ActualizarPosicionResponse>
{
    public async Task<ActualizarPosicionResponse> Handle(ActualizarPosicionCommand request, CancellationToken cancellationToken)
    {
        var obtenerDispositivoSpec = new ObtenerDispositivoSpec(request.Id);
        var dispositivo = await dispositivoTabla.FirstOrDefaultAsync(obtenerDispositivoSpec, cancellationToken);
        if (dispositivo is null)
        {
            throw new AbigeappException("Dispositivo no encontrado");
        }

        dispositivo.ActualizarPosicion(request.Latitud, request.Longitud);

        if (dispositivo.Alertas is not null)
        {
            await alertaTabla.AddRangeAsync(dispositivo.Alertas, cancellationToken);
        }

        await dispositivoTabla.UpdateAsync(dispositivo, cancellationToken);

        return new ActualizarPosicionResponse
        {
            Id = dispositivo.Id,
            Estado = dispositivo.Estado,
            Latitud = dispositivo.Latitud,
            Longitud = dispositivo.Longitud
        };
    }
}
