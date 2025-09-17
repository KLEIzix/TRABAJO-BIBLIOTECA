using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Tipos
{
    public int Id { get; set; }

    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Libros> Libros { get; set; } = new List<Libros>();
}
