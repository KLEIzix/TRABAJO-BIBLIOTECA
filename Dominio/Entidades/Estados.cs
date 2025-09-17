using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Estados
{
    public int Id { get; set; }

    public string NombreEstado { get; set; } = null!;

    public virtual ICollection<EstadosExistencias> EstadosExistencia { get; set; } = new List<EstadosExistencias>();
}
