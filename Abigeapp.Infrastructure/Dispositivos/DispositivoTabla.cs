using Abigeapp.Domain.Dispositivos;
using Abigeapp.Infrastructure.Compartido;
using Ardalis.Specification.EntityFrameworkCore;

namespace Abigeapp.Infrastructure.Dispositivos;

public class DispositivoTabla(BaseDeDatos baseDeDatos) : RepositoryBase<Dispositivo>(baseDeDatos), IDispositivoTabla;
