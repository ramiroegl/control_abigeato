namespace Abigeapp.Application.Fincas.ObtenerAlertas;

public record ObtenerAlertasResponse(IEnumerable<AlertaDto> Alertas, int Total);