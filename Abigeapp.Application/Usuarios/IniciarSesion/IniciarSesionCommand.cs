using MediatR;

namespace Abigeapp.Application.Usuarios.IniciarSesion;

public record IniciarSesionCommand : IRequest<IniciarSesionResponse>
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}
