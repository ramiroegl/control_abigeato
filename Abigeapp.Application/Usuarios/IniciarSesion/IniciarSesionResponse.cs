namespace Abigeapp.Application.Usuarios.IniciarSesion;

public record IniciarSesionResponse
{
    public required Guid Id { get; init; }
    public required string Email { get; init; }
    public required Guid FincaId { get; init; }
    public required string NombreFinca { get; init; }
}
