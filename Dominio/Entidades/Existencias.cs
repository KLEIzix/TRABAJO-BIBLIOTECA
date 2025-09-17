using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Existencias
{
    public int Id { get; set; }

    public int? Libro { get; set; }

    public int Ejemplares { get; set; }

    public virtual ICollection<EstadosExistencias> EstadosExistencia { get; set; } = new List<EstadosExistencias>();

    public virtual Libros? LibroNavigation { get; set; }

    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();
}
