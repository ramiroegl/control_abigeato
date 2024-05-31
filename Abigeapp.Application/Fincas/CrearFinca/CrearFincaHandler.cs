using Abigeapp.Domain.Fincas;
using MediatR;

namespace Abigeapp.Application.Fincas.CrearFinca;

public class CrearFincaHandler : IRequestHandler<CrearFincaCommand, CrearFincaResponse>
{
    private readonly IFincaTabla _fincaTabla;


    public CrearFincaHandler(IFincaTabla fincaTabla)
    {
        _fincaTabla = fincaTabla;
    }

    public async Task<CrearFincaResponse> Handle(CrearFincaCommand request, CancellationToken cancellationToken)
    {
        var finca = new Finca(request.Nombre, request.Latitud, request.Longitud);
        await _fincaTabla.AddAsync(finca, cancellationToken);

        return new CrearFincaResponse(finca.Id);
    }
}
