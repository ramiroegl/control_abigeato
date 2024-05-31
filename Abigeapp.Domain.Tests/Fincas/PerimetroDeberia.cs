using Abigeapp.Domain.Fincas;
using AutoFixture;

namespace Abigeapp.Domain.Tests.Fincas;

public class PerimetroDeberia
{
    private readonly IFixture _fixture = new Fixture();

    [Theory]
    [InlineData(100, 100)]
    [InlineData(-100, 100)]
    [InlineData(100, -100)]
    [InlineData(-100, -100)]
    [InlineData(-1.00000001, 1.00000001)]
    [InlineData(1.00000001, 1.00000001)]
    [InlineData(1.00000001, -1.00000001)]
    [InlineData(-1.00000001, -1.00000001)]
    public void RetornarFalseSiUnaCoordenadaEsteFueraDelPerimetro(decimal latitud, decimal longitud)
    {
        // Arrange
        var perimetro = new Perimetro(_fixture.Create<Guid>(), _fixture.Create<TipoPerimetro>(), _fixture.Create<string>())
        {
            Coordenadas = [
                new(_fixture.Create<Guid>(), -1, 1, 1),
                new(_fixture.Create<Guid>(), 1, 1, 2),
                new(_fixture.Create<Guid>(), 1, -1, 3),
                new(_fixture.Create<Guid>(), -1, -1, 4),
            ]
        };

        // Act
        var estaDentro = perimetro.EstaDentro(latitud, longitud);

        // Assert
        Assert.False(estaDentro);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(-0.99999999, 0.99999999)]
    [InlineData(0.99999999, 0.99999999)]
    [InlineData(0.99999999, -0.99999999)]
    [InlineData(-0.99999999, -0.99999999)]
    public void RetornarTrueSiUnaCoordenadaEsteDentroDelPerimetro(decimal latitud, decimal longitud)
    {
        // Arrange
        var perimetro = new Perimetro(_fixture.Create<Guid>(), _fixture.Create<TipoPerimetro>(), _fixture.Create<string>())
        {
            Coordenadas = [
                new(_fixture.Create<Guid>(), -1, 1, 1),
                new(_fixture.Create<Guid>(), 1, 1, 2),
                new(_fixture.Create<Guid>(), 1, -1, 3),
                new(_fixture.Create<Guid>(), -1, -1, 4),
            ]
        };

        // Act
        var estaDentro = perimetro.EstaDentro(latitud, longitud);

        // Assert
        Assert.True(estaDentro);
    }
}
