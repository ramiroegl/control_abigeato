using Abigeapp.Domain.Usuarios;
using Abigeapp.Infrastructure.Compartido;
using Ardalis.Specification.EntityFrameworkCore;

namespace Abigeapp.Infrastructure.Usuarios;

public class UsuarioTabla(BaseDeDatos baseDeDatos) : RepositoryBase<Usuario>(baseDeDatos), IUsuarioTabla;