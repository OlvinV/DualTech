using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DualTech.Models.Entidades;

public partial class DbdualTechContext : DbContext
{
    public DbdualTechContext()
    {
    }

    public DbdualTechContext(DbContextOptions<DbdualTechContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detalleorden> Detalleordens { get; set; }

    public virtual DbSet<Ordene> Ordenes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-IU0OJAJ;Initial Catalog=DBDualTech;Integrated Security=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__CLIENTES__71ABD087DFAED870");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.ClienteId).ValueGeneratedNever();
            entity.Property(e => e.Identidad)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Detalleorden>(entity =>
        {
            entity.HasKey(e => e.DetalleOrdenId).HasName("PK__DETALLEO__EE6A3A81EE97DF64");

            entity.ToTable("DETALLEORDEN");

            entity.Property(e => e.DetalleOrdenId).ValueGeneratedNever();
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Orden).WithMany(p => p.Detalleordens)
                .HasForeignKey(d => d.OrdenId)
                .HasConstraintName("FK__DETALLEOR__Orden__4316F928");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detalleordens)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__DETALLEOR__Produ__4222D4EF");
        });

        modelBuilder.Entity<Ordene>(entity =>
        {
            entity.HasKey(e => e.OrdenId).HasName("PK__ORDENES__C088A504DDC3B5F7");

            entity.ToTable("ORDENES");

            entity.Property(e => e.OrdenId).ValueGeneratedNever();
            entity.Property(e => e.Impuesto).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__ORDENES__Cliente__3F466844");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__PRODUCTO__A430AEA38BF9EF45");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.ProductoId).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
