using Abigeapp.Domain.Compartido;
using Abigeapp.Domain.Fincas;
using MediatR;

namespace Abigeapp.Application.Fincas.CrearPerimetro;

public class CrearPerimetroHandler : IRequestHandler<CrearPerimetroCommand, CrearPerimetroResponse>
{
    private readonly IFincaTabla _fincaTabla;
    private readonly IPerimetroTabla _perimetroTabla;

    public CrearPerimetroHandler(IFincaTabla fincaTabla, IPerimetroTabla perimetroTabla)
    {
        _fincaTabla = fincaTabla;
        _perimetroTabla = perimetroTabla;
    }

    public async Task<CrearPerimetroResponse> Handle(CrearPerimetroCommand request, CancellationToken cancellationToken)
    {
        var finca = await _fincaTabla.GetByIdAsync(request.FincaId, cancellationToken);
        if (finca is null)
        {
            throw new AbigeappException("La finca no existe");
        }

        var perimetro = new Perimetro(request.FincaId, request.Tipo, request.Descripcion);

        foreach (var coordenada in request.Coordenadas.OrderBy(c => c.Orden))
        {
            perimetro.AgregarCoordenada(coordenada.Orden, coordenada.Latitud, coordenada.Longitud);
        }

        await _perimetroTabla.AddAsync(perimetro, cancellationToken);

        return new CrearPerimetroResponse(perimetro.Id);
    }
}