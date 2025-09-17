using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Paises
{
    public int Id { get; set; }

    public string NombrePais { get; set; } = null!;

    public string? Region { get; set; }

    public virtual ICollection<Libros> Libros { get; set; } = new List<Libros>();
}
