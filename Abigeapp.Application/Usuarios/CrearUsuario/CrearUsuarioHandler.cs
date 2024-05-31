using Abigeapp.Application.Compartido;
using Abigeapp.Domain.Usuarios;
using MediatR;

namespace Abigeapp.Application.Usuarios.CrearUsuario;

public class CrearUsuarioHandler(IUsuarioTabla usuarioTabla) : IRequestHandler<CrearUsuarioCommand, CrearUsuarioResponse>
{
    public async Task<CrearUsuarioResponse> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
    {
        var passwordEncriptada = Cifrador.Encriptar(request.Password);

        var usuario = new Usuario(request.FincaId, request.Nombres, request.Apellidos, request.Email, request.Identificacion, request.Tipo, passwordEncriptada)
        {
            Telefono = request.Telefono,
            Direccion = request.Direccion,
        };

        await usuarioTabla.AddAsync(usuario, cancellationToken);

        return new CrearUsuarioResponse(usuario.Id);
    }
}