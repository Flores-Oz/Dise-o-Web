using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Parcial2.Data.Models;

namespace Parcial2.Data.Context;

public partial class BDContextMVC : DbContext
{
    public BDContextMVC()
    {
    }

    public BDContextMVC(DbContextOptions<BDContextMVC> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<MunicipiosconDepartamento> MunicipiosconDepartamentos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=GNARO\\SQLEXPRESS;Initial Catalog=BDHospital;User ID=sa;Password=ImpactRail123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.CodigoDepartamento);

            entity.ToTable("Departamento");

            entity.Property(e => e.CodigoDepartamento)
                .ValueGeneratedNever()
                .HasColumnName("codigo_departamento");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(50)
                .HasColumnName("nombre_departamento");
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
                .HasConstraintName("FK_Municipio_Departamento");
        });

        modelBuilder.Entity<MunicipiosconDepartamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MunicipiosconDepartamentos");

            entity.Property(e => e.Departamento).HasMaxLength(50);
            entity.Property(e => e.Municipio).HasMaxLength(100);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.CodigoPaciente);

            entity.ToTable("Paciente");

            entity.Property(e => e.CodigoPaciente)
                .ValueGeneratedNever()
                .HasColumnName("codigo_paciente");
            entity.Property(e => e.ApellidoPaciente)
                .HasMaxLength(50)
                .HasColumnName("apellido_paciente");
            entity.Property(e => e.CodigoMunicipio).HasColumnName("codigo_municipio");
            entity.Property(e => e.DpiPaciente)
                .HasMaxLength(20)
                .HasColumnName("dpi_paciente");
            entity.Property(e => e.EstadoPaciente).HasColumnName("estado_paciente");
            entity.Property(e => e.FechaNac)
                .HasColumnType("smalldatetime")
                .HasColumnName("fecha_nac");
            entity.Property(e => e.NombrePaciente)
                .HasMaxLength(50)
                .HasColumnName("nombre_paciente");

            entity.HasOne(d => d.CodigoMunicipioNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.CodigoMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Municipio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
