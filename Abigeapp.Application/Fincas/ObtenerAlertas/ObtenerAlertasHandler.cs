using Abigeapp.Application.Dispositivos;
using Abigeapp.Domain.Dispositivos;
using MediatR;

namespace Abigeapp.Application.Fincas.ObtenerAlertas;

public class ObtenerAlertasHandler(IAlertaTabla alertaTabla) : IRequestHandler<ObtenerAlertasQuery, ObtenerAlertasResponse>
{
    public async Task<ObtenerAlertasResponse> Handle(ObtenerAlertasQuery request, CancellationToken cancellationToken)
    {
        var obtenerAlertasSpec = new ObtenerAlertaSpec(request.FincaId, request.Pagina, request.Cantidad);
        var alertas = await alertaTabla.ListAsync(obtenerAlertasSpec, cancellationToken);
        var total = await alertaTabla.CountAsync(obtenerAlertasSpec, cancellationToken);

        return new ObtenerAlertasResponse(alertas.Select(MapAlerta), total);
    }

    private static AlertaDto MapAlerta(Alerta alerta)
    {
        return new AlertaDto
        {
            Id = alerta.Id,
            Descripcion = alerta.Descripcion,
            Estado = alerta.Estado,
            Latitud = alerta.Latitud,
            Longitud = alerta.Longitud,
            DispositivoId = alerta.DispositivoId,
            FechaCreacion = alerta.FechaCreacion,
            Dispositivo = MapDispositivo(alerta.Dispositivo!)
        };
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
