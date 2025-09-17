using System;
using System.Collections.Generic;

namespace Dominio.Entidades;

public partial class Usuarios
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Documento { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string Contraseña { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();

    public virtual ICollection<Sanciones> Sanciones { get; set; } = new List<Sanciones>();
}
