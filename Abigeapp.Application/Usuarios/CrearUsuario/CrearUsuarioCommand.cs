using Abigeapp.Domain.Usuarios;
using MediatR;

namespace Abigeapp.Application.Usuarios.CrearUsuario;

public record CrearUsuarioCommand : IRequest<CrearUsuarioResponse>
{
    public required Guid FincaId { get; init; }
    public required string Nombres { get; init; }
    public required string Apellidos { get; init; }
    public required string Identificacion { get; init; }
    public required string Email { get; init; }
    public string? Telefono { get; init; }
    public string? Direccion { get; init; }
    public required TipoUsuario Tipo { get; init; }
    public required string Password { get; init; }
}
