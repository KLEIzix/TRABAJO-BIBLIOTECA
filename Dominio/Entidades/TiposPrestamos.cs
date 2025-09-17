using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class TiposPrestamos
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();
}
