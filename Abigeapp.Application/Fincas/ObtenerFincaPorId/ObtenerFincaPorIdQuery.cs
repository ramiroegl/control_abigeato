using Abigeapp.Domain.Fincas;
using MediatR;

namespace Abigeapp.Application.Fincas.ObtenerFincaPorId;

public record ObtenerFincaPorIdQuery(Guid Id) : IRequest<ObtenerFincaPorIdResponse>;

public class ObtenerFincaPorIdHandler(IFincaTabla fincaTabla) : IRequestHandler<ObtenerFincaPorIdQuery, ObtenerFincaPorIdResponse>
{
    public async Task<ObtenerFincaPorIdResponse> Handle(ObtenerFincaPorIdQuery request, CancellationToken cancellationToken)
    {
        ObtenerFincaConCoordenadasSpec fincaConCoordenadasSpec = new(request.Id);
        Finca? finca = await fincaTabla.FirstOrDefaultAsync(fincaConCoordenadasSpec, cancellationToken);
        if (finca is null)
        {
            throw new Exception("Finca no encontrada");
        }

        return new ObtenerFincaPorIdResponse
        {
            Id = finca.Id,
            Nombre = finca.Nombre,
            Latitud = finca.Latitud,
            Longitud = finca.Longitud,
            Perimetros = finca.Perimetros!.Select(perimetro => new PerimetroDto
            {
                Id = perimetro.Id,
                Nombre = perimetro.Descripcion,
                Tipo = perimetro.Tipo,
                Coordenadas = perimetro.Coordenadas!.Select(coordenada => new CoordenadaDto
                {
                    Orden = coordenada.Orden,
                    Latitud = coordenada.Latitud,
                    Longitud = coordenada.Longitud
                })
            })
        };
    }
}
