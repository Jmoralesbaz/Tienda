using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tienda.Data
{
    public partial class ExamenContext : DbContext
    {
        public ExamenContext()
        {
        }

        public ExamenContext(DbContextOptions<ExamenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountClient> AccountClient { get; set; }
        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<ArticulosEnTiendas> ArticulosEnTiendas { get; set; }
        public virtual DbSet<ClienteConArticulos> ClienteConArticulos { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Sesiones> Sesiones { get; set; }
        public virtual DbSet<Tiendas> Tiendas { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-U7KU78J;Trusted_Connection=True;Initial Catalog=Examen");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountClient>(entity =>
            {
                entity.HasIndex(e => e.Cliente)
                    .HasName("UQ__AccountC__00D968A531C398A0")
                    .IsUnique();

                entity.HasIndex(e => e.Usuario)
                    .HasName("UQ__AccountC__E3237CF7E0AEE094")
                    .IsUnique();

                entity.Property(e => e.Activo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.ClienteNavigation)
                    .WithOne(p => p.AccountClient)
                    .HasForeignKey<AccountClient>(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AccountCl__Clien__21B6055D");
            });

            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(15, 2)");
            });

            modelBuilder.Entity<ArticulosEnTiendas>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Articulos_En_Tiendas");

                entity.HasIndex(e => new { e.Tiendas, e.Articulo })
                    .HasName("UQ_TAR")
                    .IsUnique();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.ArticuloNavigation)
                    .WithMany(p => p.ArticulosEnTiendas)
                    .HasForeignKey(d => d.Articulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__Artic__1920BF5C");

                entity.HasOne(d => d.TiendasNavigation)
                    .WithMany(p => p.ArticulosEnTiendas)
                    .HasForeignKey(d => d.Tiendas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Articulos__Tiend__182C9B23");
                entity.HasKey(d => new { d.Tiendas,d.Articulo });
            });

            modelBuilder.Entity<ClienteConArticulos>(entity =>
            {
              //  entity.HasNoKey();

                entity.ToTable("Cliente_Con_Articulos");

                entity.HasIndex(e => new { e.Cliente, e.Articulo })
                    .HasName("UQ_CAR")
                    .IsUnique();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.ArticuloNavigation)
                    .WithMany(p => p.ClienteConArticulos)
                    .HasForeignKey(d => d.Articulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente_C__Artic__1CF15040");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithMany(p => p.ClienteConArticulos)
                    .HasForeignKey(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente_C__Clien__1BFD2C07");
                entity.HasKey(d => new { d.Cliente, d.Articulo });
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasIndex(e => new { e.Nombre, e.Apellidos })
                    .HasName("UQ_NOMBRE")
                    .IsUnique();

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sesiones>(entity =>
            {
                entity.Property(e => e.Activa).HasDefaultValueSql("((1))");

                entity.Property(e => e.Sesion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Sesiones)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sesiones__Usuari__2A4B4B5E");
            });

            modelBuilder.Entity<Tiendas>(entity =>
            {
                entity.HasIndex(e => e.Sucursal)
                    .HasName("UQ__Tiendas__25B372A1ED540B69")
                    .IsUnique();

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasIndex(e => e.Cliente)
                    .HasName("UQ__Ventas__00D968A5C66D9C46")
                    .IsUnique();

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.Importe).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.ClienteNavigation)
                    .WithOne(p => p.Ventas)
                    .HasForeignKey<Ventas>(d => d.Cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ventas__Cliente__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
