using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class LibrosAutores
{
    public int Id { get; set; }

    public int? Libro { get; set; }

    public int? Autor { get; set; }

    public virtual Autores? AutorNavigation { get; set; }

    public virtual Libros? LibroNavigation { get; set; }
}
