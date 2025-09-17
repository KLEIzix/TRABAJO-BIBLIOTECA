using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Sanciones
{
    public int Id { get; set; }

    public int? Usuario { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaInicio { get; set; }

    public DateOnly? FechaFin { get; set; }

    public virtual Usuarios? UsuarioNavigation { get; set; }
}
