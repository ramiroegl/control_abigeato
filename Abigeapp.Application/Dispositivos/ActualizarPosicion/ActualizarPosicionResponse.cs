using Abigeapp.Domain.Dispositivos;

namespace Abigeapp.Application.Dispositivos.ActualizarPosicion;

public record ActualizarPosicionResponse(Guid Id, decimal Latitud, decimal Longitud, EstadoDispositivo Estado);
