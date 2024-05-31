using Abigeapp.Domain.Dispositivos;
using Abigeapp.Infrastructure.Compartido;
using Ardalis.Specification.EntityFrameworkCore;

namespace Abigeapp.Infrastructure.Dispositivos;

public class AlertaTabla(BaseDeDatos baseDeDatos) : RepositoryBase<Alerta>(baseDeDatos), IAlertaTabla;