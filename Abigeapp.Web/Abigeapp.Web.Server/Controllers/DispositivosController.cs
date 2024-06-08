using Abigeapp.Application.Dispositivos.ActualizarPosicion;
using Abigeapp.Application.Dispositivos.CrearDispositivo;
using Abigeapp.Application.Dispositivos.ObtenerPorFinca;
using Abigeapp.Application.Dispositivos.ObtenerPorId;
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

    [HttpGet("{id:guid}")]
    public Task<ObtenerDispositivoPorIdResponse> ObtenerPorId(Guid id)
    {
        return sender.Send(new ObtenerDispositivoPorIdQuery { Id = id });
    }

    [HttpPut("{id:guid}/posicion")]
    public Task<ActualizarPosicionResponse> ActualizarPosicion(Guid id, ActualizarPosicionCommand command)
    {
        return sender.Send(command with { Id = id });
    }
}
