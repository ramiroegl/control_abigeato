using Abigeapp.Application.Dispositivos;
using Abigeapp.Application.Dispositivos.ActualizarPosicion;
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

    [HttpGet]
    public Task<DispositivosPorFincaResponse> ObtenerDispositivoPorFinca([FromQuery] DispositivosPorFincaQuery query)
    {
        return sender.Send(query);
    }

    [HttpPut("{id:guid}/posicion")]
    public Task<ActualizarPosicionResponse> ActualizarPosicion(Guid id, ActualizarPosicionCommand command)
    {
        return sender.Send(command with { Id = id });
    }
}
