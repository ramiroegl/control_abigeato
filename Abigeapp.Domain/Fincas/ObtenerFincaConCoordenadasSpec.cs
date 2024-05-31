using Ardalis.Specification;

namespace Abigeapp.Domain.Fincas;

public class ObtenerFincaConCoordenadasSpec : Specification<Finca>
{
    public ObtenerFincaConCoordenadasSpec(Guid id)
    {
        Query
            .Where(finca => finca.Id == id)
            .Include(finca => finca.Perimetros!)
            .ThenInclude(perimetro => perimetro.Coordenadas);
    }
}