using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Prestamos
{
    public int Id { get; set; }

    public int? Usuario { get; set; }

    public int? TipoPrestamo { get; set; }

    public int? Existencia { get; set; }

    public DateOnly FechaPrestamo { get; set; }

    public DateOnly? FechaDevolucion { get; set; }

    public DateOnly? FechaEntregaReal { get; set; }

    public virtual Existencias? ExistenciaNavigation { get; set; }

    public virtual TiposPrestamos? TipoPrestamoNavigation { get; set; }

    public virtual Usuarios? UsuarioNavigation { get; set; }
}
