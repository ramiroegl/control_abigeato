using Abigeapp.Domain.Fincas;
using Abigeapp.Infrastructure.Compartido;
using Ardalis.Specification.EntityFrameworkCore;

namespace Abigeapp.Infrastructure.Fincas;

public class PerimetroTabla(BaseDeDatos baseDeDatos) : RepositoryBase<Perimetro>(baseDeDatos), IPerimetroTabla;