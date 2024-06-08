using Abigeapp.Application.Fincas.CrearFinca;
using Abigeapp.Application.Fincas.ObtenerAlertas;
using Abigeapp.Application.Fincas.ObtenerPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Abigeapp.Web.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FincasController(ISender sender) : ControllerBase
{
    [HttpPost]
    public Task<CrearFincaResponse> CrearFinca(CrearFincaCommand command)
    {
        return sender.Send(command);
    }

    [HttpGet("{id:guid}")]
    public Task<ObtenerFincaPorIdResponse> ObtenerFincaPorId(Guid id)
    {
        return sender.Send(new ObtenerFincaPorIdQuery(id));
    }

    [HttpGet("{id:guid}/alertas")]
    public Task<ObtenerAlertasResponse> ObtenerAlertas(Guid id, [FromQuery] ObtenerAlertasQuery query)
    {
        return sender.Send(query with { FincaId = id });
    }
}
