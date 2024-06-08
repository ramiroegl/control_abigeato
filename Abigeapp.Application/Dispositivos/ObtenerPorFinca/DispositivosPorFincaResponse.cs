namespace Abigeapp.Application.Dispositivos.ObtenerPorFinca;

public record DispositivosPorFincaResponse(IEnumerable<DispositivoDto> Dispositivos, int Total);