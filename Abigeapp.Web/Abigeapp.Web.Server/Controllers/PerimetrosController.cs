using Abigeapp.Application.Fincas.CrearPerimetro;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Abigeapp.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PerimetrosController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<CrearPerimetroResponse> CrearPerimetro(CrearPerimetroCommand command)
    {
        return sender.Send(command);
    }
}
