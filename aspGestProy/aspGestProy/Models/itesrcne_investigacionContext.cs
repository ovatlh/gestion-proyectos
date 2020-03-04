using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspGestProy.Models
{
    public partial class itesrcne_investigacionContext : DbContext
    {
        public itesrcne_investigacionContext()
        {
        }

        public itesrcne_investigacionContext(DbContextOptions<itesrcne_investigacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Asesor> Asesor { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Entregable> Entregable { get; set; }
        public virtual DbSet<Lineainvestigacion> Lineainvestigacion { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Proyectoalumno> Proyectoalumno { get; set; }
        public virtual DbSet<Proyectoasesor> Proyectoasesor { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Tipoinvestigacion> Tipoinvestigacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=204.93.216.11; user id=itesrcne_invest; password=programadores1nvest; database=itesrcne_investigacion;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador);

                entity.ToTable("administrador");

                entity.HasIndex(e => e.IdCarrera)
                    .HasName("fk_Administrador_Carrera1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Administrador_Usuario1_idx");

                entity.Property(e => e.IdAdministrador).HasColumnType("int(11)");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ClaveEscolar)
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IdCarrera)
                    .HasColumnName("idCarrera")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Administrador_Carrera1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Administrador)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Administrador_Usuario1");
            });

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno);

                entity.ToTable("alumno");

                entity.HasIndex(e => e.IdCarrera)
                    .HasName("fk_Alumno_Carrera1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Alumno_Usuario1_idx");

                entity.Property(e => e.IdAlumno).HasColumnType("int(11)");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ClaveEscolar)
                    .IsRequired()
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.IdCarrera)
                    .HasColumnName("idCarrera")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Semestre).HasColumnType("int(11)");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Alumno_Carrera1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Alumno_Usuario1");
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.ToTable("area");

                entity.Property(e => e.IdArea)
                    .HasColumnName("idArea")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SectorEstrategico)
                    .IsRequired()
                    .HasColumnType("varchar(200)");
            });

            modelBuilder.Entity<Asesor>(entity =>
            {
                entity.HasKey(e => e.IdAsesor);

                entity.ToTable("asesor");

                entity.HasIndex(e => e.IdCarrera)
                    .HasName("fk_Asesor_Carrera1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_Asesor_Usuario1_idx");

                entity.Property(e => e.IdAsesor).HasColumnType("int(11)");

                entity.Property(e => e.ApellidoMaterno).HasColumnType("varchar(45)");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.ClaveEscolar).HasColumnType("varchar(8)");

                entity.Property(e => e.Cvu)
                    .IsRequired()
                    .HasColumnName("CVU")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(60)");

                entity.Property(e => e.Genero).HasColumnType("tinyint(4)");

                entity.Property(e => e.IdCarrera)
                    .HasColumnName("idCarrera")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Asesor)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Asesor_Carrera1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Asesor)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Asesor_Usuario1");
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.HasKey(e => e.IdCarrera);

                entity.ToTable("carrera");

                entity.Property(e => e.IdCarrera)
                    .HasColumnName("idCarrera")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("idCategoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Entregable>(entity =>
            {
                entity.HasKey(e => e.IdEntregable);

                entity.ToTable("entregable");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("fk_Entregable_Proyecto1_idx");

                entity.Property(e => e.IdEntregable)
                    .HasColumnName("idEntregable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("idProyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Entregable)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Entregable_Proyecto1");
            });

            modelBuilder.Entity<Lineainvestigacion>(entity =>
            {
                entity.HasKey(e => e.IdLineaInvestigacion);

                entity.ToTable("lineainvestigacion");

                entity.HasIndex(e => e.IdAsesorResponsable)
                    .HasName("fk_LineaInvestigacion_Asesor1_idx");

                entity.HasIndex(e => e.IdCarrera)
                    .HasName("fk_LineaInvestigacion_Carrera1_idx");

                entity.Property(e => e.IdLineaInvestigacion)
                    .HasColumnName("idLineaInvestigacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.IdAsesorResponsable).HasColumnType("int(11)");

                entity.Property(e => e.IdCarrera)
                    .HasColumnName("idCarrera")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.IdAsesorResponsableNavigation)
                    .WithMany(p => p.Lineainvestigacion)
                    .HasForeignKey(d => d.IdAsesorResponsable)
                    .HasConstraintName("fk_LineaInvestigacion_Asesor1");

                entity.HasOne(d => d.IdCarreraNavigation)
                    .WithMany(p => p.Lineainvestigacion)
                    .HasForeignKey(d => d.IdCarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_LineaInvestigacion_Carrera1");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.IdProyecto);

                entity.ToTable("proyecto");

                entity.HasIndex(e => e.IdArea)
                    .HasName("fk_Proyecto_Area1_idx");

                entity.HasIndex(e => e.IdAsesorResponsable)
                    .HasName("fk_Proyecto_Asesor1_idx");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("fk_Proyecto_Categoria1_idx");

                entity.HasIndex(e => e.IdLineaInvestigacion)
                    .HasName("fk_Proyecto_LineaInvestigacion1_idx");

                entity.HasIndex(e => e.IdTipoInvestigacion)
                    .HasName("fk_Proyecto_TipoInvestigacion1_idx");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("idProyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AutorizadoAdministrador).HasColumnType("tinyint(4)");

                entity.Property(e => e.AutorizadoAsesor).HasColumnType("tinyint(4)");

                entity.Property(e => e.AutorizadoComite).HasColumnType("tinyint(4)");

                entity.Property(e => e.Avance).HasColumnType("int(11)");

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.FechaTentativaTerminacion).HasColumnType("date");

                entity.Property(e => e.FechaTerminacion).HasColumnType("date");

                entity.Property(e => e.IdArea)
                    .HasColumnName("idArea")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdAsesorResponsable).HasColumnType("int(11)");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("idCategoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdLineaInvestigacion)
                    .HasColumnName("idLineaInvestigacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoInvestigacion)
                    .HasColumnName("idTipoInvestigacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MemoriaPdf)
                    .IsRequired()
                    .HasColumnName("MemoriaPDF")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.ObjetivoGeneral)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ObjetivosEspecificos)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Proyecto_Area1");

                entity.HasOne(d => d.IdAsesorResponsableNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdAsesorResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Proyecto_Asesor1");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Proyecto_Categoria1");

                entity.HasOne(d => d.IdLineaInvestigacionNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdLineaInvestigacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Proyecto_LineaInvestigacion1");

                entity.HasOne(d => d.IdTipoInvestigacionNavigation)
                    .WithMany(p => p.Proyecto)
                    .HasForeignKey(d => d.IdTipoInvestigacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Proyecto_TipoInvestigacion1");
            });

            modelBuilder.Entity<Proyectoalumno>(entity =>
            {
                entity.HasKey(e => e.IdProyectoAlumno);

                entity.ToTable("proyectoalumno");

                entity.HasIndex(e => e.IdAlumno)
                    .HasName("fk_Alumno_has_Proyecto_Alumno1_idx");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("fk_Alumno_has_Proyecto_Proyecto1_idx");

                entity.HasIndex(e => e.IdRol)
                    .HasName("fk_Alumno_has_Proyecto_Rol1_idx");

                entity.Property(e => e.IdProyectoAlumno).HasColumnType("int(11)");

                entity.Property(e => e.IdAlumno).HasColumnType("int(11)");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("idProyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.Proyectoalumno)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Alumno_has_Proyecto_Alumno1");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Proyectoalumno)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Alumno_has_Proyecto_Proyecto1");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Proyectoalumno)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Alumno_has_Proyecto_Rol1");
            });

            modelBuilder.Entity<Proyectoasesor>(entity =>
            {
                entity.HasKey(e => e.IdProyectoAsesor);

                entity.ToTable("proyectoasesor");

                entity.HasIndex(e => e.IdAsesor)
                    .HasName("fk_Asesor_has_Proyecto1_Asesor1_idx");

                entity.HasIndex(e => e.IdProyecto)
                    .HasName("fk_Asesor_has_Proyecto1_Proyecto1_idx");

                entity.Property(e => e.IdProyectoAsesor).HasColumnType("int(11)");

                entity.Property(e => e.IdAsesor)
                    .HasColumnName("idAsesor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProyecto)
                    .HasColumnName("idProyecto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.IdAsesorNavigation)
                    .WithMany(p => p.Proyectoasesor)
                    .HasForeignKey(d => d.IdAsesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Asesor_has_Proyecto1_Asesor1");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.Proyectoasesor)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Asesor_has_Proyecto1_Proyecto1");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("rol");

                entity.Property(e => e.IdRol)
                    .HasColumnName("idRol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Tipoinvestigacion>(entity =>
            {
                entity.HasKey(e => e.IdTipoInvestigacion);

                entity.ToTable("tipoinvestigacion");

                entity.Property(e => e.IdTipoInvestigacion)
                    .HasColumnName("idTipoInvestigacion")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClaveEscolar).HasColumnType("varchar(8)");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.TipoUsuario).HasColumnType("int(11)");
            });
        }
    }
}
