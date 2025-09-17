using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class EstadosExistencias
{
    public int Id { get; set; }

    public int? Existencias { get; set; }

    public int? Estado { get; set; }

    public DateTime? FechaCambio { get; set; }

    public virtual Estado? EstadoNavigation { get; set; }

    public virtual Existencias? ExistenciaNavigation { get; set; }
}
