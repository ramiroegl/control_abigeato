using Abigeapp.Domain.Fincas;

namespace Abigeapp.Domain.Dispositivos;

public class Dispositivo
{
    public Dispositivo(Guid perimetroId, string codigo, decimal latitud, decimal longitud)
    {
        Id = Guid.NewGuid();
        PerimetroId = perimetroId;
        Codigo = codigo;
        Latitud = latitud;
        Longitud = longitud;
        Estado = EstadoDispositivo.Dentro;
        FechaCreacion = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; set; }
    public Guid PerimetroId { get; set; }
    public Perimetro? Perimetro { get; set; }
    public string Codigo { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public EstadoDispositivo Estado { get; set; }
    public DateTimeOffset FechaCreacion { get; set; }
    public DateTimeOffset? FechaModificacion { get; set; }
    public ICollection<Alerta>? Alertas { get; set; }
}
