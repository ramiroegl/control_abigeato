using MediatR;

namespace Abigeapp.Application.Fincas.CrearFinca;

public record CrearFincaCommand(string Nombre, decimal Latitud, decimal Longitud) : IRequest<CrearFincaResponse>;
