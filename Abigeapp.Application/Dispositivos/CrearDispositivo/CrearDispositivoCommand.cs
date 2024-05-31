using Abigeapp.Domain.Compartido;
using Abigeapp.Domain.Dispositivos;
using Abigeapp.Domain.Fincas;
using MediatR;

namespace Abigeapp.Application.Dispositivos.CrearDispositivo;

public record CrearDispositivoCommand(Guid PerimetroId, string Codigo, decimal Latitud, decimal Longitud) : IRequest<CrearDispositivoResponse>;

public class CrearDispositivoHandler : IRequestHandler<CrearDispositivoCommand, CrearDispositivoResponse>
{
    private readonly IPerimetroTabla _perimetroRepository;
    private readonly IDispositivoTabla _dispositivoRepository;

    public CrearDispositivoHandler(IPerimetroTabla perimetroRepository, IDispositivoTabla dispositivoRepository)
    {
        _perimetroRepository = perimetroRepository;
        _dispositivoRepository = dispositivoRepository;
    }

    public async Task<CrearDispositivoResponse> Handle(CrearDispositivoCommand request, CancellationToken cancellationToken)
    {
        var perimetro = await _perimetroRepository.GetByIdAsync(request.PerimetroId, cancellationToken);
        if (perimetro is null)
        {
            throw new AbigeappException("El perimetro no existe");
        }

        var dispositivo = new Dispositivo(request.PerimetroId, request.Codigo, request.Latitud, request.Longitud);
        await _dispositivoRepository.AddAsync(dispositivo, cancellationToken);

        return new CrearDispositivoResponse(dispositivo.Id);
    }
}