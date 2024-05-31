using Abigeapp.Domain.Dispositivos;
using Abigeapp.Domain.Fincas;
using Abigeapp.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Abigeapp.Infrastructure.Compartido;

public class BaseDeDatos(DbContextOptions<BaseDeDatos> options) : DbContext(options)
{
    public DbSet<Dispositivo> Dispositivos { get; set; }
    public DbSet<Alerta> Alertas { get; set; }
    public DbSet<Finca> Fincas { get; set; }
    public DbSet<Perimetro> Perimetros { get; set; }
    public DbSet<Coordenada> Coordenadas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
