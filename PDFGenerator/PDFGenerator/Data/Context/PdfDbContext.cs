using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PDFGenerator.Data.Models;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PDFGenerator.Data.Context;

public partial class PdfDbContext : DbContext
{
    public PdfDbContext()
    {
    }

    public PdfDbContext(DbContextOptions<PdfDbContext> options)
           : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Detallefactura> Detallefacturas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.MunicipioId, "MunicipioId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.MunicipioId).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);

            entity.HasOne(d => d.Municipio).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.MunicipioId)
                .HasConstraintName("cliente_ibfk_1");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Detallefactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("detallefactura");

            entity.HasIndex(e => e.FacturaId, "FacturaId");

            entity.HasIndex(e => e.ProductoId, "ProductoId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Cantidad).HasColumnType("int(11)");
            entity.Property(e => e.FacturaId).HasColumnType("int(11)");
            entity.Property(e => e.PrecioUnitario).HasPrecision(10, 2);
            entity.Property(e => e.ProductoId).HasColumnType("int(11)");
            entity.Property(e => e.Total).HasPrecision(10, 2);

            entity.HasOne(d => d.Factura).WithMany(p => p.Detallefacturas)
                .HasForeignKey(d => d.FacturaId)
                .HasConstraintName("detallefactura_ibfk_1");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detallefacturas)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("detallefactura_ibfk_2");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("factura");

            entity.HasIndex(e => e.ClienteId, "ClienteId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ClienteId).HasColumnType("int(11)");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Total).HasPrecision(10, 2);

            entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("factura_ibfk_1");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("municipio");

            entity.HasIndex(e => e.DepartamentoId, "DepartamentoId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DepartamentoId).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Departamento).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("municipio_ibfk_1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("producto");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasPrecision(10, 2);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
