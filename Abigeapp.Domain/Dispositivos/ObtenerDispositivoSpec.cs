using Ardalis.Specification;

namespace Abigeapp.Domain.Dispositivos;

public class ObtenerDispositivoSpec : Specification<Dispositivo>
{
    public ObtenerDispositivoSpec(Guid id)
    {
        Query
            .Where(dispositivo => dispositivo.Id == id)
            .Include(dispositivo => dispositivo.Perimetro!)
            .ThenInclude(perimetro => perimetro.Coordenadas);
    }

    public ObtenerDispositivoSpec(Guid fincaId, int pagina, int cantidad)
    {
        Query
            .Where(dispositivo => dispositivo.Perimetro!.FincaId == fincaId)
            .Skip((pagina - 1) * cantidad)
            .Take(cantidad);
    }
}
