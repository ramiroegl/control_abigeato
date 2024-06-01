using Abigeapp.Application.Compartido;
using Abigeapp.Domain.Compartido;
using Abigeapp.Domain.Usuarios;
using MediatR;

namespace Abigeapp.Application.Usuarios.IniciarSesion;

public class IniciarSesionHandler(IUsuarioTabla usuarioTabla) : IRequestHandler<IniciarSesionCommand, IniciarSesionResponse>
{
    public async Task<IniciarSesionResponse> Handle(IniciarSesionCommand request, CancellationToken cancellationToken)
    {
        ObtenerUsuarioPorEmailSpec usuarioPorEmailSpec = new(request.Email);
        var usuario = await usuarioTabla.FirstOrDefaultAsync(usuarioPorEmailSpec, cancellationToken);
        if (usuario is null || !Cifrador.Verificar(usuario.Password, request.Password))
        {
            throw new AbigeappException("Email o contraseña incorrecta");
        }

        return new IniciarSesionResponse
        {
            Id = usuario.Id,
            FincaId = usuario.FincaId,
            Email = usuario.Email,
            NombreFinca = usuario.Finca!.Nombre
        };
    }
}