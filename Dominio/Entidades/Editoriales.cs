using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Editoriales
{
    public int Id { get; set; }

    public string NombreEditorial { get; set; } = null!;

    public string? SitioWeb { get; set; }

    public virtual ICollection<Libros> Libros { get; set; } = new List<Libros>();
}
