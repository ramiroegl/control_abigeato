using Abigeapp.Domain.Compartido;
using Abigeapp.Domain.Dispositivos;
using MediatR;

namespace Abigeapp.Application.Dispositivos.LeerAlerta;

public record LeerAlertaCommand(Guid Id) : IRequest;

public class LeerAlertaHandler(IAlertaTabla alertaTabla) : IRequestHandler<LeerAlertaCommand>
{
    public async Task Handle(LeerAlertaCommand request, CancellationToken cancellationToken)
    {
        var alerta = await alertaTabla.GetByIdAsync(request.Id, cancellationToken);
        if (alerta is null)
        {
            throw new AbigeappException("Alerta no encontrada");
        }

        alerta.Estado = EstadoAlerta.Resuelta;
        await alertaTabla.UpdateAsync(alerta, cancellationToken);
    }
}