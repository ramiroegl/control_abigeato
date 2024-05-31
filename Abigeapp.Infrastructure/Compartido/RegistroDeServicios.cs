using Abigeapp.Domain.Dispositivos;
using Abigeapp.Domain.Fincas;
using Abigeapp.Domain.Usuarios;
using Abigeapp.Infrastructure.Dispositivos;
using Abigeapp.Infrastructure.Fincas;
using Abigeapp.Infrastructure.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Abigeapp.Infrastructure.Compartido;

public static class RegistroDeServicios
{
    public static IServiceCollection AgregarBaseDeDatos(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<BaseDeDatos>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
            })
            .AddScoped<IPerimetroTabla, PerimetroTabla>()
            .AddScoped<IDispositivoTabla, DispositivoTabla>()
            .AddScoped<IFincaTabla, FincaTabla>()
            .AddScoped<IAlertaTabla, AlertaTabla>()
            .AddScoped<IUsuarioTabla, UsuarioTabla>();
    }
}
