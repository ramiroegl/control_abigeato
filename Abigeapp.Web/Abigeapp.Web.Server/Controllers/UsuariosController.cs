using Abigeapp.Application.Usuarios.CrearUsuario;
using Abigeapp.Application.Usuarios.IniciarSesion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Abigeapp.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<CrearUsuarioResponse> CrearUsuario(CrearUsuarioCommand command)
    {
        return sender.Send(command);
    }

    [HttpPost("login")]
    public Task<IniciarSesionResponse> IniciarSesion(IniciarSesionCommand command)
    {
        return sender.Send(command);
    }
}
