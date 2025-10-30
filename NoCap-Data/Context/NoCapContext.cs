using Microsoft.EntityFrameworkCore;
using NoCap_Data.Data;

namespace NoCap_Data.Context;

public class NoCapContext(DbContextOptions<NoCapContext> options) : DbContext(options)
{
    public DbSet<CarritoDetalle> CarritoDetalles { get; set; }
    public DbSet<Carritos> Carritos { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<Estados> Estados { get; set; }
    public DbSet<Marcas> Marcas { get; set; }
    public DbSet<OrdenCompra> OrdenCompras { get; set; }
    public DbSet<Pagos> Pagos { get; set; }
    public DbSet<Productos> Productos { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carritos>()
          .HasOne(c => c.Estado)
          .WithMany()
          .HasForeignKey(c => c.EstadoId)
          .OnDelete(DeleteBehavior.NoAction); 

        modelBuilder.Entity<Carritos>()
            .HasOne(c => c.Usuario)
            .WithMany()
            .HasForeignKey(c => c.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Roles>().HasData(
            new Roles
            {
                RolId = 1,
                NombreRol = "Usuario"
            },
            new Roles
            {
                RolId = 2,
                NombreRol = "Administrador"
            }
            );
        modelBuilder.Entity<Marcas>().HasData(
            new Marcas
            {
                MarcaId = 1,
                Nombre = "New Era"
            },
            new Marcas
            {
                MarcaId = 2,
                Nombre = "Armani"
            }

            );
        modelBuilder.Entity<Estados>().HasData(
            new Estados
            {
                EstadoId = 1,
                Nombre = "Pagado"
            },
            new Estados
            {
                EstadoId = 2,
                Nombre = "Pendiente"
            },
            new Estados
            {
                EstadoId = 3,
                Nombre = "Agotado "
            },
            new Estados
            {
                EstadoId = 4,
                Nombre = "Disponibles"
            },
            new Estados
            {
                EstadoId = 5,
                Nombre = "Cancelada"
            },
            new Estados
            {
                EstadoId = 6,
                Nombre = "En revision"
            },
            new Estados
            {
                EstadoId = 7,
                Nombre = "Comprado"
            }
        );
    }
}
