using Dominio.Entidades;
using Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        public Conexion() { }

        public Conexion(string connectionString)
        {
            this.StringConexion = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(this.StringConexion))
            {
                optionsBuilder.UseSqlServer(this.StringConexion, p => { });
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
        }
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
        
    }
}

/*
public class Conexion : BibliotecaDbContext, IConexion
{
    public string? StringConexion { get; set; }

    public Conexion(string connectionString)
        : base(new DbContextOptionsBuilder<BibliotecaDbContext>()
              .UseSqlServer(connectionString)
              .Options)
    {
        StringConexion = connectionString;
    }
}
*/
