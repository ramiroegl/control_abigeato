using MediatR;

namespace Abigeapp.Application.Fincas.ObtenerPorId;

public record ObtenerFincaPorIdQuery(Guid Id) : IRequest<ObtenerFincaPorIdResponse>;
