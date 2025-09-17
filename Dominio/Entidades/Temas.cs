using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Temas
{
    public int Id { get; set; }

    public string NombreTema { get; set; } = null!;

    public string? AreaConocimiento { get; set; }

    public virtual ICollection<LibrosTemas> LibrosTemas { get; set; } = new List<LibrosTemas>();
}
