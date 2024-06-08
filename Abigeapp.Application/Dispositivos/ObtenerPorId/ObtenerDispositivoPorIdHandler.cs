using Abigeapp.Application.Fincas;
using Abigeapp.Domain.Compartido;
using Abigeapp.Domain.Dispositivos;
using Abigeapp.Domain.Fincas;
using MediatR;

namespace Abigeapp.Application.Dispositivos.ObtenerPorId;

public class ObtenerDispositivoPorIdHandler(IDispositivoTabla dispositivoTabla) : IRequestHandler<ObtenerDispositivoPorIdQuery, ObtenerDispositivoPorIdResponse>
{
    public async Task<ObtenerDispositivoPorIdResponse> Handle(ObtenerDispositivoPorIdQuery request, CancellationToken cancellationToken)
    {
        var dispositivoSpec = new ObtenerDispositivoSpec(request.Id);
        var dispositivo = await dispositivoTabla.FirstOrDefaultAsync(dispositivoSpec, cancellationToken);
        if (dispositivo is null)
        {
            throw new AbigeappException("Dispositivo no encontrado");
        }

        return MapDispositivo(dispositivo);
    }

    private static ObtenerDispositivoPorIdResponse MapDispositivo(Dispositivo dispositivo)
    {
        return new ObtenerDispositivoPorIdResponse
        {
            Id = dispositivo.Id,
            Codigo = dispositivo.Codigo,
            Estado = dispositivo.Estado,
            Latitud = dispositivo.Latitud,
            Longitud = dispositivo.Longitud,
            Perimetro = MapPerimetro(dispositivo.Perimetro!)
        };
    }

    private static PerimetroDto MapPerimetro(Perimetro perimetro)
    {
        return new PerimetroDto
        {
            Id = perimetro.Id,
            Nombre = perimetro.Descripcion,
            Tipo = perimetro.Tipo,
            Coordenadas = perimetro.Coordenadas!.OrderBy(coordenada => coordenada.Orden)
            .Select(coordenada => new CoordenadaDto
            {
                Orden = coordenada.Orden,
                Latitud = coordenada.Latitud,
                Longitud = coordenada.Longitud
            })
        };
    }
}