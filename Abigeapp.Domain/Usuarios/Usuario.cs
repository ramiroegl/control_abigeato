using Abigeapp.Domain.Fincas;

namespace Abigeapp.Domain.Usuarios;

public class Usuario
{
    public Usuario(Guid fincaId, string nombres, string apellidos, string email, string identificacion, TipoUsuario tipo, string password)
    {
        Id = Guid.NewGuid();
        FincaId = fincaId;
        Nombres = nombres;
        Apellidos = apellidos;
        Email = email;
        Identificacion = identificacion;
        Tipo = tipo;
        Password = password;
    }

    public Guid Id { get; set; }
    public Guid FincaId { get; set; }
    public Finca? Finca { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Email { get; set; }
    public string Identificacion { get; set; }
    public TipoUsuario Tipo { get; set; }
    public string Password { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public bool Activo { get; set; }
}
