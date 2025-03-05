using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ZeroTwo.Data.Models;

namespace ZeroTwo.Data.Context;

public partial class BDContextMVC : DbContext
{
    public BDContextMVC()
    {
    }

    public BDContextMVC(DbContextOptions<BDContextMVC> options)
        : base(options)
    {
    }

    public virtual DbSet<BitacoraCliente> BitacoraClientes { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<EncaCompra> EncaCompras { get; set; }

    public virtual DbSet<EncaVentum> EncaVenta { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<VListadodeCliente> VListadodeClientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ALLEGRO\\SQLEXPRESS;Initial Catalog=Ejercicio1;User ID=sa;Password=GotchardFever456; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<BitacoraCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Bitacora_Cliente");

            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(50)
                .HasColumnName("apellido_cliente");
            entity.Property(e => e.CodigoMunicipio).HasColumnName("codigo_municipio");
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(300)
                .HasColumnName("direccion_cliente");
            entity.Property(e => e.EstadoCliente).HasColumnName("estado_cliente");
            entity.Property(e => e.FechaEvento)
                .HasColumnType("smalldatetime")
                .HasColumnName("fecha_evento");
            entity.Property(e => e.FechanacCliente)
                .HasColumnType("smalldatetime")
                .HasColumnName("fechanac_cliente");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.NitCliente)
                .HasMaxLength(20)
                .HasColumnName("nit_cliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(50)
                .HasColumnName("nombre_cliente");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombre_municipio");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(12)
                .HasColumnName("telefono_cliente");
            entity.Property(e => e.TipoEvento)
                .HasMaxLength(15)
                .HasColumnName("tipo_evento");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.NitCliente).HasName("PK__Cliente__4F1796DE167F220D");

            entity.ToTable("Cliente");

            entity.Property(e => e.NitCliente)
                .HasMaxLength(20)
                .HasColumnName("nit_cliente");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(100)
                .HasColumnName("apellido_cliente");
            entity.Property(e => e.CodigoMunicipio).HasColumnName("codigo_municipio");
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(300)
                .HasColumnName("direccion_cliente");
            entity.Property(e => e.EstadoCliente).HasColumnName("estado_cliente");
            entity.Property(e => e.FechanacCliente)
                .HasColumnType("smalldatetime")
                .HasColumnName("fechanac_cliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .HasColumnName("nombre_cliente");
            entity.Property(e => e.TelefonoCliente)
                .HasMaxLength(12)
                .HasColumnName("telefono_cliente");

            entity.HasOne(d => d.CodigoMunicipioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.CodigoMunicipio)
                .HasConstraintName("FK_Cliente_Municipio");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.CodigoDepartamento);

            entity.ToTable("Departamento");

            entity.Property(e => e.CodigoDepartamento)
                .ValueGeneratedNever()
                .HasColumnName("codigo_departamento");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(100)
                .HasColumnName("nombre_departamento");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.CodigoDetalleCompra).HasName("PK__Detalle___65222FF5929F068A");

            entity.ToTable("Detalle_Compra");

            entity.Property(e => e.CodigoDetalleCompra).HasColumnName("codigo_detalle_compra");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoCompra).HasColumnName("codigo_compra");
            entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");
            entity.Property(e => e.PrecioCosto)
                .HasColumnType("money")
                .HasColumnName("precio_costo");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("money")
                .HasColumnName("precio_venta");
            entity.Property(e => e.Subtotal)
                .HasColumnType("money")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.CodigoCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.CodigoCompra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_C__codig__20C1E124");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.CodigoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_C__codig__1ED998B2");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity.HasKey(e => e.CodigoDetalleVenta).HasName("PK__Detalle___647F5689361C6577");

            entity.ToTable("Detalle_Venta");

            entity.Property(e => e.CodigoDetalleVenta).HasColumnName("codigo_detalle_venta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");
            entity.Property(e => e.CodigoVenta).HasColumnName("codigo_venta");
            entity.Property(e => e.PrecioCosto)
                .HasColumnType("money")
                .HasColumnName("precio_costo");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("money")
                .HasColumnName("precio_venta");
            entity.Property(e => e.Subtotal)
                .HasColumnType("money")
                .HasColumnName("subtotal");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.CodigoProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_V__codig__1FCDBCEB");

            entity.HasOne(d => d.CodigoVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.CodigoVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_V__codig__22AA2996");
        });

        modelBuilder.Entity<EncaCompra>(entity =>
        {
            entity.HasKey(e => e.CodigoCompra).HasName("PK__Enca_Com__101C1978BF5315B6");

            entity.ToTable("Enca_Compra");

            entity.Property(e => e.CodigoCompra).HasColumnName("codigo_compra");
            entity.Property(e => e.DpiCliente)
                .HasMaxLength(20)
                .HasColumnName("dpi_cliente");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("smalldatetime")
                .HasColumnName("fecha_compra");
            entity.Property(e => e.TotalCompra)
                .HasColumnType("money")
                .HasColumnName("total_compra");
            entity.Property(e => e.TotalProducto).HasColumnName("total_producto");

            entity.HasOne(d => d.DpiClienteNavigation).WithMany(p => p.EncaCompras)
                .HasForeignKey(d => d.DpiCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enca_Comp__dpi_c__1DE57479");
        });

        modelBuilder.Entity<EncaVentum>(entity =>
        {
            entity.HasKey(e => e.CodigoVenta).HasName("PK__Enca_Ven__064A4E43271DE8C4");

            entity.ToTable("Enca_Venta");

            entity.Property(e => e.CodigoVenta).HasColumnName("codigo_venta");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("smalldatetime")
                .HasColumnName("fecha_venta");
            entity.Property(e => e.NitProveedor)
                .HasMaxLength(15)
                .HasColumnName("nit_proveedor");
            entity.Property(e => e.TotalProductos).HasColumnName("total_productos");
            entity.Property(e => e.TotalVenta)
                .HasColumnType("money")
                .HasColumnName("total_venta");

            entity.HasOne(d => d.NitProveedorNavigation).WithMany(p => p.EncaVenta)
                .HasForeignKey(d => d.NitProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enca_Vent__nit_p__21B6055D");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.CodigoMarca).HasName("PK__Marca__95266CC6112B0806");

            entity.ToTable("Marca");

            entity.Property(e => e.CodigoMarca)
                .ValueGeneratedNever()
                .HasColumnName("codigo_marca");
            entity.Property(e => e.NombreMarca)
                .HasMaxLength(100)
                .HasColumnName("nombre_marca");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.CodigoMunicipio);

            entity.ToTable("Municipio");

            entity.Property(e => e.CodigoMunicipio)
                .ValueGeneratedNever()
                .HasColumnName("codigo_municipio");
            entity.Property(e => e.CodigoDepartamento).HasColumnName("codigo_departamento");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(100)
                .HasColumnName("nombre_municipio");

            entity.HasOne(d => d.CodigoDepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.CodigoDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Municipio_Departamento1");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PK__Producto__105107A93D4F3356");

            entity.ToTable("Producto");

            entity.Property(e => e.CodigoProducto).HasColumnName("codigo_producto");
            entity.Property(e => e.CodigoMarca).HasColumnName("codigo_marca");
            entity.Property(e => e.ExistenciaProducto).HasColumnName("existencia_producto");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .HasColumnName("nombre_producto");
            entity.Property(e => e.PrecioCosto)
                .HasColumnType("money")
                .HasColumnName("precio_costo");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("money")
                .HasColumnName("precio_venta");

            entity.HasOne(d => d.CodigoMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoMarca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__codigo__239E4DCF");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.NitProveedor).HasName("PK__Proveedo__EA42DE80DC35E22D");

            entity.ToTable("Proveedor");

            entity.Property(e => e.NitProveedor)
                .HasMaxLength(15)
                .HasColumnName("nit_proveedor");
            entity.Property(e => e.DireccionProveedor)
                .HasMaxLength(300)
                .HasColumnName("direccion_proveedor");
            entity.Property(e => e.NombreProveedor)
                .HasMaxLength(150)
                .HasColumnName("nombre_proveedor");
            entity.Property(e => e.TelefonoProveedor)
                .HasMaxLength(12)
                .HasColumnName("telefono_proveedor");
        });

        modelBuilder.Entity<VListadodeCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_ListadodeClientes");

            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(300);
            entity.Property(e => e.FechaNac).HasColumnType("smalldatetime");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .HasColumnName("NIT");
            entity.Property(e => e.Nombres).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
