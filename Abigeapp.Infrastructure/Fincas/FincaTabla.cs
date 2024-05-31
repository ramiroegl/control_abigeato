using Abigeapp.Domain.Fincas;
using Abigeapp.Infrastructure.Compartido;
using Ardalis.Specification.EntityFrameworkCore;

namespace Abigeapp.Infrastructure.Fincas;

public class FincaTabla(BaseDeDatos baseDeDatos) : RepositoryBase<Finca>(baseDeDatos), IFincaTabla;
