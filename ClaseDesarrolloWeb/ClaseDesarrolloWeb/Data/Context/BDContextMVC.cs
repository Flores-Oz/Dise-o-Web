using System;
using System.Collections.Generic;
using ClaseDesarrolloWeb.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ClaseDesarrolloWeb.Data.Context;

public partial class BDContextMVC : DbContext
{
    public BDContextMVC()
    {
    }

    public BDContextMVC(DbContextOptions<BDContextMVC> options)
        : base(options)
    {
    }

    public virtual DbSet<AlumUsua> AlumUsuas { get; set; }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AsignaCursosalum> AsignaCursosalums { get; set; }

    public virtual DbSet<BitacoraCarrera> BitacoraCarreras { get; set; }

    public virtual DbSet<BitacoraGrado> BitacoraGrados { get; set; }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Ciclo> Ciclos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetallePago> DetallePagos { get; set; }

    public virtual DbSet<DetallePensum> DetallePensums { get; set; }

    public virtual DbSet<EncPago> EncPagos { get; set; }

    public virtual DbSet<Encargado> Encargados { get; set; }

    public virtual DbSet<Grado> Grados { get; set; }

    public virtual DbSet<Inscripcion> Inscripcions { get; set; }

    public virtual DbSet<Jornadum> Jornada { get; set; }

    public virtual DbSet<Me> Mes { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Notum> Nota { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<PagosGrado> PagosGrados { get; set; }

    public virtual DbSet<Paisnacimiento> Paisnacimientos { get; set; }

    public virtual DbSet<Pensum> Pensums { get; set; }

    public virtual DbSet<Seccion> Seccions { get; set; }

    public virtual DbSet<Unidad> Unidads { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<View1> View1s { get; set; }

    public virtual DbSet<View2> View2s { get; set; }

    public virtual DbSet<VistaAlumno> VistaAlumnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ALLEGRO\\SQLEXPRESS;Initial Catalog=Parcial2_Progra5;User ID=sa;Password=GotchardFever456; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<AlumUsua>(entity =>
        {
            entity.HasKey(e => e.IdUsuAlu).HasName("PK__alum_usu__899143DB2319F8B1");

            entity.ToTable("alum_usua");

            entity.Property(e => e.IdUsuAlu).HasColumnName("id_usu_alu");
            entity.Property(e => e.Carne)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("smalldatetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.CarneNavigation).WithMany(p => p.AlumUsuas)
                .HasForeignKey(d => d.Carne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__alum_usua__Carne__787EE5A0");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AlumUsuas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__alum_usua__id_us__08B54D69");
        });

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Carne).HasName("PK__alumno__68A109FF7F60ED59");

            entity.ToTable("alumno");

            entity.Property(e => e.Carne).HasMaxLength(20);
            entity.Property(e => e.Apellido1Alumno)
                .HasMaxLength(20)
                .HasColumnName("apellido1_alumno");
            entity.Property(e => e.Apellido2Alumno)
                .HasMaxLength(20)
                .HasColumnName("apellido2_alumno");
            entity.Property(e => e.CelularAlumno)
                .HasMaxLength(20)
                .HasColumnName("celular_alumno");
            entity.Property(e => e.DireccionAlumno)
                .HasMaxLength(100)
                .HasColumnName("direccion_alumno");
            entity.Property(e => e.EstadoAlumno).HasColumnName("estado_alumno");
            entity.Property(e => e.Fechaingreso)
                .HasColumnType("datetime")
                .HasColumnName("fechaingreso");
            entity.Property(e => e.Fechanac).HasColumnType("smalldatetime");
            entity.Property(e => e.IdEncargado).HasColumnName("id_encargado");
            entity.Property(e => e.IdMuni).HasColumnName("id_muni");
            entity.Property(e => e.Nombre1Alumno)
                .HasMaxLength(20)
                .HasColumnName("nombre1_alumno");
            entity.Property(e => e.Nombre2Alumno)
                .HasMaxLength(20)
                .HasColumnName("nombre2_alumno");
            entity.Property(e => e.NumeroActualizacion).HasColumnName("numero_actualizacion");
            entity.Property(e => e.SexoAlumno)
                .HasMaxLength(20)
                .HasColumnName("Sexo_Alumno");

            entity.HasOne(d => d.IdEncargadoNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdEncargado)
                .HasConstraintName("FK_alumno_Encargado");

            entity.HasOne(d => d.IdMuniNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdMuni)
                .HasConstraintName("FK_alumno_municipio");
        });

        modelBuilder.Entity<AsignaCursosalum>(entity =>
        {
            entity.HasKey(e => e.IdAlumCurso);

            entity.ToTable("asigna_cursosalum");

            entity.Property(e => e.IdAlumCurso)
                .HasMaxLength(20)
                .HasColumnName("id_alum_curso");
            entity.Property(e => e.IdCurso)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("ID_Curso");
            entity.Property(e => e.IdInscripcion).HasColumnName("ID_Inscripcion");
            entity.Property(e => e.Resultado).HasMaxLength(12);

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.AsignaCursosalums)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_asigna_cursosalum_curso");

            entity.HasOne(d => d.IdInscripcionNavigation).WithMany(p => p.AsignaCursosalums)
                .HasForeignKey(d => d.IdInscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_asigna_cursosalum_inscripcion");
        });

        modelBuilder.Entity<BitacoraCarrera>(entity =>
        {
            entity.HasKey(e => e.IdBitacora).HasName("PK_bitacora_carrera_1");

            entity.ToTable("bitacora_carrera");

            entity.Property(e => e.IdBitacora).HasColumnName("id_bitacora");
            entity.Property(e => e.EstadoCarrera).HasColumnName("estado_carrera");
            entity.Property(e => e.FechaAccion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_accion");
            entity.Property(e => e.IdCarrera).HasColumnName("id_carrera");
            entity.Property(e => e.NombreCarrera)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nombre_carrera");
            entity.Property(e => e.TipoAccion)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("tipo_accion");
        });

        modelBuilder.Entity<BitacoraGrado>(entity =>
        {
            entity.HasKey(e => e.IdBitacoraGrado);

            entity.ToTable("bitacora_grado");

            entity.Property(e => e.IdBitacoraGrado).HasColumnName("id_bitacoraGrado");
            entity.Property(e => e.Accion)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("accion");
            entity.Property(e => e.EstadoGrado).HasColumnName("estado_grado");
            entity.Property(e => e.FechaOperacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_operacion");
            entity.Property(e => e.IdGrado).HasColumnName("ID_grado");
            entity.Property(e => e.NomGrado)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Nom_grado");
        });

        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.IdCarrera);

            entity.ToTable("carrera", tb => tb.HasTrigger("T_actualizaCarrera"));

            entity.Property(e => e.IdCarrera)
                .HasMaxLength(5)
                .HasColumnName("id_carrera");
            entity.Property(e => e.EstadoCarrera).HasColumnName("estado_carrera");
            entity.Property(e => e.NombreCarrera)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nombre_carrera");
        });

        modelBuilder.Entity<Ciclo>(entity =>
        {
            entity.HasKey(e => e.IdCiclo).HasName("PK__ciclo__A78E2FA34F7CD00D");

            entity.ToTable("ciclo");

            entity.Property(e => e.IdCiclo)
                .ValueGeneratedNever()
                .HasColumnName("id_ciclo");
            entity.Property(e => e.EstadoCiclo).HasColumnName("estado_ciclo");
            entity.Property(e => e.NombreCiclo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre_ciclo");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__curso__DC72196F03317E3D");

            entity.ToTable("curso");

            entity.Property(e => e.IdCurso)
                .HasMaxLength(30)
                .HasColumnName("ID_Curso");
            entity.Property(e => e.EstadoCurso).HasColumnName("estado_curso");
            entity.Property(e => e.NomCurso)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nom_Curso");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__departam__64F37A160EA330E9");

            entity.ToTable("departamento");

            entity.Property(e => e.IdDepartamento)
                .ValueGeneratedNever()
                .HasColumnName("id_departamento");
            entity.Property(e => e.NombreDepartamento)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre_departamento");
        });

        modelBuilder.Entity<DetallePago>(entity =>
        {
            entity.HasKey(e => e.IdDetPago).HasName("PK__detalle___0941B07429572725");

            entity.ToTable("detalle_pago");

            entity.Property(e => e.IdDetPago)
                .HasMaxLength(15)
                .HasColumnName("id_det_pago");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.CantidadAbono)
                .HasColumnType("money")
                .HasColumnName("cantidad_abono");
            entity.Property(e => e.IdCurso)
                .HasMaxLength(10)
                .HasColumnName("id_curso");
            entity.Property(e => e.IdEncpago)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("id_encpago");
            entity.Property(e => e.IdInscripcion).HasColumnName("id_inscripcion");
            entity.Property(e => e.IdPago).HasColumnName("id_pago");
            entity.Property(e => e.IdRubro).HasColumnName("Id_rubro");
            entity.Property(e => e.NumeroMes).HasColumnName("numero_mes");
            entity.Property(e => e.Valor)
                .HasColumnType("money")
                .HasColumnName("valor");

            entity.HasOne(d => d.IdEncpagoNavigation).WithMany(p => p.DetallePagos)
                .HasForeignKey(d => d.IdEncpago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_pago_enc_pago");

            entity.HasOne(d => d.IdPagoNavigation).WithMany(p => p.DetallePagos)
                .HasForeignKey(d => d.IdPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_pago_pago");
        });

        modelBuilder.Entity<DetallePensum>(entity =>
        {
            entity.HasKey(e => e.IdDetPen).HasName("PK__detalle___D8F93A1FAA2FAA62");

            entity.ToTable("detalle_pensum");

            entity.Property(e => e.IdDetPen).HasColumnName("ID_Det_Pen");
            entity.Property(e => e.IdCurso)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("ID_Curso");
            entity.Property(e => e.IdPensum)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("ID_Pensum");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.DetallePensums)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__detalle_p__ID_Cu__797309D9");

            entity.HasOne(d => d.IdPensumNavigation).WithMany(p => p.DetallePensums)
                .HasForeignKey(d => d.IdPensum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_pensum_pensum");
        });

        modelBuilder.Entity<EncPago>(entity =>
        {
            entity.HasKey(e => e.IdEncpago).HasName("PK__enc_pago__5E6B23B3534D60F1");

            entity.ToTable("enc_pago");

            entity.Property(e => e.IdEncpago)
                .HasMaxLength(15)
                .HasColumnName("id_encpago");
            entity.Property(e => e.BoletaPago)
                .HasMaxLength(20)
                .HasColumnName("Boleta_pago");
            entity.Property(e => e.Concepto).HasMaxLength(100);
            entity.Property(e => e.DescripcionPago).HasColumnName("Descripcion_pago");
            entity.Property(e => e.FechaBoleta).HasColumnName("fecha_boleta");
            entity.Property(e => e.FechaEncpago).HasColumnName("fecha_encpago");
            entity.Property(e => e.IdInscripcion).HasColumnName("ID_Inscripcion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.NoRecibo)
                .HasMaxLength(10)
                .HasColumnName("no_recibo");
            entity.Property(e => e.TipoPago).HasColumnName("tipo_pago");
            entity.Property(e => e.TotalPago)
                .HasColumnType("money")
                .HasColumnName("total_pago");

            entity.HasOne(d => d.IdInscripcionNavigation).WithMany(p => p.EncPagos)
                .HasForeignKey(d => d.IdInscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__enc_pago__ID_Ins__01142BA1");
        });

        modelBuilder.Entity<Encargado>(entity =>
        {
            entity.HasKey(e => e.IdEncargado);

            entity.ToTable("Encargado");

            entity.Property(e => e.IdEncargado).HasColumnName("id_encargado");
            entity.Property(e => e.ApellidoEncargado)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("apellido_encargado");
            entity.Property(e => e.DirecEncargado)
                .HasMaxLength(100)
                .HasColumnName("direc_encargado");
            entity.Property(e => e.NombreEncargado)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre_encargado");
            entity.Property(e => e.TelCasa)
                .HasMaxLength(20)
                .HasColumnName("tel_casa");
            entity.Property(e => e.TelCel)
                .HasMaxLength(20)
                .HasColumnName("tel_cel");
        });

        modelBuilder.Entity<Grado>(entity =>
        {
            entity.HasKey(e => e.IdGrado).HasName("PK__grado__91EA22D307020F21");

            entity.ToTable("grado", tb =>
                {
                    tb.HasTrigger("T_dGrado");
                    tb.HasTrigger("T_uGrado");
                });

            entity.Property(e => e.IdGrado).HasColumnName("ID_grado");
            entity.Property(e => e.EstadoGrado).HasColumnName("estado_grado");
            entity.Property(e => e.NomGrado)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Nom_grado");
        });

        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion).HasName("PK__inscripc__B84666E0164452B1");

            entity.ToTable("inscripcion");

            entity.Property(e => e.IdInscripcion).HasColumnName("ID_Inscripcion");
            entity.Property(e => e.CantidadIns)
                .HasColumnType("money")
                .HasColumnName("Cantidad_ins");
            entity.Property(e => e.CantidadMensual)
                .HasColumnType("money")
                .HasColumnName("Cantidad_mensual");
            entity.Property(e => e.Carne)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.ContadorMes).HasColumnName("Contador_mes");
            entity.Property(e => e.EstadoIns).HasColumnName("Estado_Ins");
            entity.Property(e => e.FechaFinal).HasColumnName("Fecha_Final");
            entity.Property(e => e.FechaInicial).HasColumnName("Fecha_inicial");
            entity.Property(e => e.FechaInscripcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("Fecha_Inscripcion");
            entity.Property(e => e.IdCiclo).HasColumnName("id_ciclo");
            entity.Property(e => e.IdJornada).HasColumnName("id_jornada");
            entity.Property(e => e.IdPensum)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("ID_Pensum");
            entity.Property(e => e.IdRubroIns).HasColumnName("Id_rubro_ins");
            entity.Property(e => e.IdRubroMen).HasColumnName("Id_rubro_men");
            entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.TotalPagar)
                .HasColumnType("money")
                .HasColumnName("Total_pagar");

            entity.HasOne(d => d.CarneNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.Carne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inscripci__Carne__778AC167");

            entity.HasOne(d => d.IdCicloNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdCiclo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inscripci__id_ci__10566F31");

            entity.HasOne(d => d.IdJornadaNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdJornada)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__inscripci__id_jo__0E6E26BF");

            entity.HasOne(d => d.IdPensumNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdPensum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_inscripcion_pensum");

            entity.HasOne(d => d.IdSeccionNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.IdSeccion)
                .HasConstraintName("FK_inscripcion_seccion");
        });

        modelBuilder.Entity<Jornadum>(entity =>
        {
            entity.HasKey(e => e.IdJornada).HasName("PK__jornada__6BD46D1ADF22884B");

            entity.ToTable("jornada");

            entity.Property(e => e.IdJornada).HasColumnName("id_jornada");
            entity.Property(e => e.NombreJornada)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre_jornada");
        });

        modelBuilder.Entity<Me>(entity =>
        {
            entity.HasKey(e => e.IdMes);

            entity.Property(e => e.IdMes)
                .ValueGeneratedNever()
                .HasColumnName("id_mes");
            entity.Property(e => e.Mes)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("mes");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__municipi__83444092403A8C7D");

            entity.ToTable("municipio");

            entity.Property(e => e.IdMunicipio)
                .ValueGeneratedNever()
                .HasColumnName("id_municipio");
            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.NombreMunicipio)
                .HasMaxLength(50)
                .HasColumnName("nombre_municipio");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_municipio_departamento");
        });

        modelBuilder.Entity<Notum>(entity =>
        {
            entity.HasKey(e => e.IdNota).HasName("PK__nota__A3147DAE25869641");

            entity.ToTable("nota");

            entity.Property(e => e.IdNota)
                .HasMaxLength(20)
                .HasColumnName("ID_Nota");
            entity.Property(e => e.Argumento)
                .HasMaxLength(20)
                .HasColumnName("argumento");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("smalldatetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.IdAlumCurso)
                .HasMaxLength(20)
                .HasColumnName("id_alum_curso");
            entity.Property(e => e.IdCursoProf).HasColumnName("ID_CursoProf");
            entity.Property(e => e.IdUnidad).HasColumnName("id_unidad");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Literal)
                .HasMaxLength(50)
                .HasColumnName("literal");
            entity.Property(e => e.Notafinal).HasColumnName("notafinal");
            entity.Property(e => e.TipoNota)
                .HasMaxLength(20)
                .HasColumnName("tipo_nota");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Zona).HasColumnName("zona");

            entity.HasOne(d => d.IdAlumCursoNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdAlumCurso)
                .HasConstraintName("FK_nota_asigna_cursosalum");

            entity.HasOne(d => d.IdUnidadNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdUnidad)
                .HasConstraintName("FK__nota__id_unidad__06CD04F7");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__pago__0941B07421B6055D");

            entity.ToTable("pago");

            entity.Property(e => e.IdPago)
                .ValueGeneratedNever()
                .HasColumnName("id_pago");
            entity.Property(e => e.EstadoPago).HasColumnName("estado_pago");
            entity.Property(e => e.NomPago)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nom_pago");
            entity.Property(e => e.Valor)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<PagosGrado>(entity =>
        {
            entity.HasKey(e => e.IdPagosGrado);

            entity.ToTable("Pagos_Grado");

            entity.Property(e => e.IdPagosGrado)
                .ValueGeneratedNever()
                .HasColumnName("ID_Pagos_grado");
            entity.Property(e => e.CantidadPagos).HasColumnName("cantidad_pagos");
            entity.Property(e => e.CoutaCompu).HasColumnName("couta_compu");
            entity.Property(e => e.EstadoCouta).HasColumnName("Estado_Couta");
            entity.Property(e => e.IdCarrera)
                .HasMaxLength(5)
                .HasColumnName("id_carrera");
            entity.Property(e => e.IdJornada).HasColumnName("id_jornada");
            entity.Property(e => e.ValorInscripcion)
                .HasColumnType("money")
                .HasColumnName("Valor_Inscripcion");
            entity.Property(e => e.ValorMensualidad)
                .HasColumnType("money")
                .HasColumnName("Valor_Mensualidad");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.PagosGrados)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("FK_Pagos_Grado_carrera");
        });

        modelBuilder.Entity<Paisnacimiento>(entity =>
        {
            entity.HasKey(e => e.IdPaisnac).HasName("PK__paisnaci__CE8CC8A766603565");

            entity.ToTable("paisnacimiento");

            entity.Property(e => e.IdPaisnac).HasColumnName("id_paisnac");
            entity.Property(e => e.NombrePais)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("nombre_pais");
        });

        modelBuilder.Entity<Pensum>(entity =>
        {
            entity.HasKey(e => e.IdPensum).HasName("PK__pensum__8FCA598E0EA330E9");

            entity.ToTable("pensum");

            entity.Property(e => e.IdPensum)
                .HasMaxLength(20)
                .HasColumnName("ID_Pensum");
            entity.Property(e => e.EstadoPensum).HasColumnName("Estado_Pensum");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("smalldatetime")
                .HasColumnName("Fecha_Inicio");
            entity.Property(e => e.IdCarrera)
                .HasMaxLength(5)
                .HasColumnName("id_carrera");
            entity.Property(e => e.IdGrado).HasColumnName("id_grado");
            entity.Property(e => e.NomPensum)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnName("Nom_Pensum");

            entity.HasOne(d => d.IdCarreraNavigation).WithMany(p => p.Pensums)
                .HasForeignKey(d => d.IdCarrera)
                .HasConstraintName("FK_pensum_carrera");

            entity.HasOne(d => d.IdGradoNavigation).WithMany(p => p.Pensums)
                .HasForeignKey(d => d.IdGrado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pensum_semestre");
        });

        modelBuilder.Entity<Seccion>(entity =>
        {
            entity.HasKey(e => e.IdSeccion).HasName("PK__seccion__7C91FD81EC12FF3D");

            entity.ToTable("seccion");

            entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");
            entity.Property(e => e.NombreSeccion)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("nombre_seccion");
        });

        modelBuilder.Entity<Unidad>(entity =>
        {
            entity.HasKey(e => e.IdUnidad).HasName("PK__unidad__95D7C92B7E8FD894");

            entity.ToTable("unidad");

            entity.Property(e => e.IdUnidad)
                .ValueGeneratedNever()
                .HasColumnName("id_unidad");
            entity.Property(e => e.EstadoUnidad).HasColumnName("estado_unidad");
            entity.Property(e => e.FechaFinal)
                .HasColumnType("smalldatetime")
                .HasColumnName("fecha_final");
            entity.Property(e => e.FechaInicial)
                .HasColumnType("smalldatetime")
                .HasColumnName("fecha_inicial");
            entity.Property(e => e.NombreUnidad)
                .HasMaxLength(50)
                .HasColumnName("nombre_unidad");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__4E3E04AD38996AB5");

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Contrasenia)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Estadousu).HasColumnName("estadousu");
            entity.Property(e => e.IdTipousu).HasColumnName("id_tipousu");
            entity.Property(e => e.NomModServ)
                .HasMaxLength(50)
                .HasColumnName("nom_mod_serv");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<View1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_1");

            entity.Property(e => e.EstadoCurso).HasColumnName("estado_curso");
            entity.Property(e => e.IdCarrera)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnName("id_carrera");
            entity.Property(e => e.IdCurso)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("ID_Curso");
            entity.Property(e => e.IdPensum)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("ID_Pensum");
            entity.Property(e => e.NomCurso)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Nom_Curso");
            entity.Property(e => e.NombreCarrera)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nombre_carrera");
        });

        modelBuilder.Entity<View2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_2");

            entity.Property(e => e.NomGrado)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Nom_grado");
            entity.Property(e => e.NombreCarrera)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nombre_carrera");
        });

        modelBuilder.Entity<VistaAlumno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VistaAlumno");

            entity.Property(e => e.Apellido1)
                .HasMaxLength(20)
                .HasColumnName("Apellido 1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(20)
                .HasColumnName("Apellido 2");
            entity.Property(e => e.Carne)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Departamento)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("Fecha Ingreso");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("smalldatetime")
                .HasColumnName("Fecha Nacimiento");
            entity.Property(e => e.Municipio).HasMaxLength(50);
            entity.Property(e => e.Nombre1)
                .HasMaxLength(20)
                .HasColumnName("Nombre 1");
            entity.Property(e => e.Nombre2)
                .HasMaxLength(20)
                .HasColumnName("Nombre 2");
            entity.Property(e => e.Sexo).HasMaxLength(20);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
