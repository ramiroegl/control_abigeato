using Abigeapp.Application.Dispositivos.LeerAlerta;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Abigeapp.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlertasController(ISender sender) : ControllerBase
{
    [HttpPut("{id:guid}/leer")]
    public Task LeerAlerta(Guid id)
    {
        return sender.Send(new LeerAlertaCommand(id));
    }
}
