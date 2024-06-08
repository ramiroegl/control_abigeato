using MediatR;

namespace Abigeapp.Application.Fincas.ObtenerAlertas;

public record ObtenerAlertasQuery : IRequest<ObtenerAlertasResponse>
{
    public required Guid FincaId { get; init; }
    public required int Pagina { get; init; }
    public required int Cantidad { get; init; }
}
