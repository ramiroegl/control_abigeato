namespace Abigeapp.Domain.Fincas;

public class Perimetro
{
    public Perimetro(Guid fincaId, TipoPerimetro tipo, string descripcion)
    {
        Id = Guid.NewGuid();
        FincaId = fincaId;
        Tipo = tipo;
        Descripcion = descripcion;
    }

    public Guid Id { get; set; }
    public Guid FincaId { get; set; }
    public Finca? Finca { get; set; }
    public TipoPerimetro Tipo { get; set; }
    public string Descripcion { get; set; }
    public ICollection<Coordenada>? Coordenadas { get; set; }
}
