using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Libros
{
    public int Id { get; set; }

    public int? Editorial { get; set; }

    public int? Pais { get; set; }

    public int? Tipo { get; set; }

    public string? Isbn { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Edicion { get; set; }

    public DateOnly? FechaLanzamiento { get; set; }

    public virtual Editoriales? EditorialNavigation { get; set; }

    public virtual ICollection<Existencias> Existencia { get; set; } = new List<Existencias>();

    public virtual ICollection<LibrosAutores> LibrosAutores { get; set; } = new List<LibrosAutores>();

    public virtual ICollection<LibrosTemas> LibrosTemas { get; set; } = new List<LibrosTemas>();

    public virtual Paises? PaisNavigation { get; set; }

    public virtual Tipos? TipoNavigation { get; set; }
}
