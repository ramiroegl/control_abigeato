using Ardalis.Specification;

namespace Abigeapp.Domain.Usuarios;

public class ObtenerUsuarioPorEmailSpec : Specification<Usuario>
{
    public ObtenerUsuarioPorEmailSpec(string email)
    {
        Query
            .Where(usuario => usuario.Email == email)
            .Include(usuario => usuario.Finca);
    }
}