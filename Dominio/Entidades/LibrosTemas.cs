using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class LibrosTemas
{
    public int Id { get; set; }

    public int? Libro { get; set; }

    public int? Tema { get; set; }

    public virtual Libros? LibroNavigation { get; set; }

    public virtual Temas? TemaNavigation { get; set; }
}
