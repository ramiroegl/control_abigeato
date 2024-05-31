using Abigeapp.Domain.Dispositivos;
using Abigeapp.Domain.Fincas;
using AutoFixture;

namespace Abigeapp.Domain.Tests.Dispositivos;

public class DispositivoDeberia
{
    private readonly IFixture _fixture = new Fixture();

    [Fact]
    public void ActualizarLatitudYLongitud()
    {
        // Arrange
        decimal latitud = _fixture.Create<decimal>();
        decimal longitud = _fixture.Create<decimal>();
        var dispositivo = new Dispositivo(_fixture.Create<Guid>(), _fixture.Create<string>(), _fixture.Create<decimal>(), _fixture.Create<decimal>());

        // Act
        dispositivo.ActualizarPosicion(latitud, longitud);

        // Assert
        Assert.Equal(latitud, dispositivo.Latitud);
        Assert.Equal(longitud, dispositivo.Longitud);
    }

    [Fact]
    public void ActualizarEstadoYCrearAlertaCuandoEsteFueraDelPerimetro()
    {
        // Arrange
        decimal latitud = 2;
        decimal longitud = 0.6m;
        var perimetroId = _fixture.Create<Guid>();
        var perimetro = new Perimetro(perimetroId, _fixture.Create<TipoPerimetro>(), _fixture.Create<string>())
        {
            Coordenadas = [
                new(perimetroId, -1, 1, 1),
                new(perimetroId, 1, 1, 2),
                new(perimetroId, 1, -1, 3),
                new(perimetroId, -1, -1, 4),
            ]
        };

        var dispositivo = new Dispositivo(perimetro.Id, _fixture.Create<string>(), _fixture.Create<decimal>(), _fixture.Create<decimal>())
        {
            Perimetro = perimetro
        };

        // Act
        dispositivo.ActualizarPosicion(latitud, longitud);

        // Assert
        Assert.Equal(EstadoDispositivo.Fuera, dispositivo.Estado);
        Assert.NotNull(dispositivo.Alertas);
        Assert.Single(dispositivo.Alertas);
    }
}
