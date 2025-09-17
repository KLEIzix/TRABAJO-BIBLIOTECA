using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositorio.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        public DbSet<Auditorias>? Auditoria { get; set; }
        public DbSet<Autores>? Autores { get; set; }
        public DbSet<Editoriales>? Editorial { get; set; }
        public DbSet<Estados>? Estado { get; set; }
        public DbSet<EstadosExistencias>? EstadoExistencia { get; set; }
        public DbSet<Existencias>? Existencia { get; set; }
        public DbSet<Libros>? Libro { get; set; }
        public DbSet<LibrosAutores>? LibroAutor { get; set; }
        public DbSet<LibrosTemas>? LibroTema { get; set; }
        public DbSet<Paises>? Pais { get; set; }
        public DbSet<Prestamos>? Prestamo { get; set; }
        public DbSet<TiposPrestamos>? TipoPrestamo { get; set; }
        public DbSet<Sanciones>? Sancion { get; set; }
        public DbSet<Temas>? Tema { get; set; }
        public DbSet<Tipos>? Tipo { get; set; }
        public DbSet<Usuarios>? Usuario { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}