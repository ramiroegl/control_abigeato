using Abigeapp.Domain.Compartido;
using Abigeapp.Domain.Dispositivos;
using Abigeapp.Domain.Fincas;
using MediatR;

namespace Abigeapp.Application.Dispositivos.CrearDispositivo;

public record CrearDispositivoCommand(Guid PerimetroId, string Codigo, decimal Latitud, decimal Longitud) : IRequest<CrearDispositivoResponse>;

public class CrearDispositivoHandler(IPerimetroTabla perimetroRepository, IDispositivoTabla dispositivoRepository, IAlertaTabla alertaTabla) : IRequestHandler<CrearDispositivoCommand, CrearDispositivoResponse>
{
    public async Task<CrearDispositivoResponse> Handle(CrearDispositivoCommand request, CancellationToken cancellationToken)
    {
        var perimetro = await perimetroRepository.GetByIdAsync(request.PerimetroId, cancellationToken);
        if (perimetro is null)
        {
            throw new AbigeappException("El perimetro no existe");
        }

        var dispositivo = new Dispositivo(request.PerimetroId, request.Codigo, request.Latitud, request.Longitud);
        await dispositivoRepository.AddAsync(dispositivo, cancellationToken);

        dispositivo.ActualizarPosicion(request.Latitud, request.Longitud);

        if (dispositivo.Alertas is not null)
        {
            await alertaTabla.AddRangeAsync(dispositivo.Alertas, cancellationToken);
        }

        return new CrearDispositivoResponse(dispositivo.Id);
    }
}