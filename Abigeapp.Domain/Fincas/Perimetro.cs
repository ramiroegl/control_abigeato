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

    public void AgregarCoordenada(int orden, decimal latitud, decimal longitud)
    {
        Coordenadas ??= [];

        var coordenada = new Coordenada(Id, orden, latitud, longitud);
        Coordenadas.Add(coordenada);
    }

    public bool EstaDentro(decimal latitud, decimal longitud)
    {
        if (Coordenadas is null)
        {
            throw new InvalidOperationException("El perimetro no tiene coordenadas asignadas");
        }

        var coordenadas = Coordenadas.OrderBy(c => c.Orden).ToList();
        var n = coordenadas.Count;
        var j = n - 1;
        var estaDentro = false;

        for (var i = 0; i < n; i++)
        {
            if (coordenadas[i].Latitud < latitud && coordenadas[j].Latitud >= latitud || coordenadas[j].Latitud < latitud && coordenadas[i].Latitud >= latitud)
            {
                if (coordenadas[i].Longitud + (latitud - coordenadas[i].Latitud) / (coordenadas[j].Latitud - coordenadas[i].Latitud) * (coordenadas[j].Longitud - coordenadas[i].Longitud) < longitud)
                {
                    estaDentro = !estaDentro;
                }
            }

            j = i;
        }

        return estaDentro;
    }
}
