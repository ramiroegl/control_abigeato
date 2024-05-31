namespace Abigeapp.Domain.Fincas;

public class Coordenada
{
    public Coordenada(Guid perimetroId, int orden, decimal latitud, decimal longitud)
    {
        Id = Guid.NewGuid();
        Orden = orden;
        PerimetroId = perimetroId;
        Latitud = latitud;
        Longitud = longitud;
    }

    public Guid Id { get; set; }
    public Guid PerimetroId { get; set; }
    public Perimetro? Perimetro { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public int Orden { get; set; }
}
