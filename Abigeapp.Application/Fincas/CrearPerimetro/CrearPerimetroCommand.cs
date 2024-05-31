using Abigeapp.Domain.Fincas;
using MediatR;

namespace Abigeapp.Application.Fincas.CrearPerimetro;

public record CrearPerimetroCommand(Guid FincaId, string Descripcion, TipoPerimetro Tipo, IEnumerable<CoordenadaDto> Coordenadas) : IRequest<CrearPerimetroResponse>;
