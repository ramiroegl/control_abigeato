namespace Abigeapp.Domain.Dispositivos;

public class Alerta
{
    public Alerta(Guid dispositivoId, string descripcion, decimal latitud, decimal longitud)
    {
        DispositivoId = dispositivoId;
        Descripcion = descripcion;
        FechaCreacion = DateTimeOffset.UtcNow;
        Latitud = latitud;
        Longitud = longitud;
        Estado = EstadoAlerta.Pendiente;
    }

    public Guid Id { get; set; }
    public Guid DispositivoId { get; set; }
    public Dispositivo? Dispositivo { get; set; }
    public string Descripcion { get; set; }
    public DateTimeOffset FechaCreacion { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public EstadoAlerta Estado { get; set; }
}
