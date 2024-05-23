using Abigeapp.Domain.Usuarios;

namespace Abigeapp.Domain.Fincas;

public class Finca
{
    public Finca(string nombre, decimal latitud, decimal longitud)
    {
        Id = Guid.NewGuid();
        Nombre = nombre;
        Latitud = latitud;
        Longitud = longitud;
    }

    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public decimal Latitud { get; set; }
    public decimal Longitud { get; set; }
    public ICollection<Usuario>? Usuarios { get; set; }
    public ICollection<Perimetro>? Perimetros { get; set; }
}
