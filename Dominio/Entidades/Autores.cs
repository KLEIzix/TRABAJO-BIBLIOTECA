using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Autores
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Nacionalidad { get; set; }

    public virtual ICollection<LibrosAutores> LibrosAutores { get; set; } = new List<LibrosAutores>();
}
