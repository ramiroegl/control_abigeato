using Abigeapp.Application.Dispositivos.PorFinca;

namespace Abigeapp.Application.Dispositivos;

public record DispositivosPorFincaResponse(IEnumerable<DispositivoDto> Dispositivos, int Total);