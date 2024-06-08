using Ardalis.Specification;

namespace Abigeapp.Domain.Dispositivos;

public class ObtenerAlertaSpec : Specification<Alerta>
{
    public ObtenerAlertaSpec(Guid fincaId, int pagina, int cantidad)
    {
        Query
            .Where(alerta => alerta.Dispositivo!.Perimetro!.FincaId == fincaId)
            .Include(alerta => alerta.Dispositivo)
            .OrderByDescending(alerta => alerta.FechaCreacion)
            .Skip((pagina - 1) * cantidad)
            .Take(cantidad);
    }
}