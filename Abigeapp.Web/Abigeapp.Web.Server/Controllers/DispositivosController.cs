using Abigeapp.Application.Dispositivos.CrearDispositivo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Abigeapp.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DispositivosController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<CrearDispositivoResponse> CrearDispositivo(CrearDispositivoCommand command)
    {
        return sender.Send(command);
    }
}
