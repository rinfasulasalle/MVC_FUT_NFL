using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_FUT_NFL.Models;

public partial class NflBdContext : DbContext
{
    public NflBdContext()
    {
    }

    public NflBdContext(DbContextOptions<NflBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Estadio> Estadios { get; set; }

    public virtual DbSet<Jugadore> Jugadores { get; set; }

    public virtual DbSet<Noticia> Noticias { get; set; }

    public virtual DbSet<Partido> Partidos { get; set; }

    public virtual DbSet<RelJugadoresEquipo> RelJugadoresEquipos { get; set; }

    public virtual DbSet<Resultado> Resultados { get; set; }

    public virtual DbSet<Video> Videos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ROGER;Database=NFL_BD;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__COMENTAR__3213E83FCD1A92F9");

            entity.ToTable("COMENTARIOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comentario1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("comentario");
            entity.Property(e => e.IdPartido).HasColumnName("id_partido");

            entity.HasOne(d => d.IdPartidoNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPartido)
                .HasConstraintName("FK__COMENTARI__id_pa__49C3F6B7");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EQUIPOS__3213E83F15BFD8C0");

            entity.ToTable("EQUIPOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Puntuacion)
                .HasDefaultValueSql("((0))")
                .HasColumnName("puntuacion");
        });

        modelBuilder.Entity<Estadio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESTADIOS__3213E83F62DFE35C");

            entity.ToTable("ESTADIOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Jugadore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JUGADORE__3213E83FA0FFDDF6");

            entity.ToTable("JUGADORES");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Estadisticas)
                .IsUnicode(false)
                .HasColumnName("estadisticas");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.Posicion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("posicion");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Noticia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NOTICIAS__3213E83F4DB02131");

            entity.ToTable("NOTICIAS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContenidoNoticia)
                .HasColumnType("text")
                .HasColumnName("contenido_noticia");
            entity.Property(e => e.TituloNoticia)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("titulo_noticia");
            entity.Property(e => e.UrlImgNoticia)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url_img_noticia");
        });

        modelBuilder.Entity<Partido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PARTIDOS__3213E83F40F92C9A");

            entity.ToTable("PARTIDOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdEquipo1).HasColumnName("id_equipo_1");
            entity.Property(e => e.IdEquipo2).HasColumnName("id_equipo_2");
            entity.Property(e => e.IdEstadio).HasColumnName("id_estadio");
            entity.Property(e => e.Tipo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.IdEquipo1Navigation).WithMany(p => p.PartidoIdEquipo1Navigations)
                .HasForeignKey(d => d.IdEquipo1)
                .HasConstraintName("FK__PARTIDOS__id_equ__4316F928");

            entity.HasOne(d => d.IdEquipo2Navigation).WithMany(p => p.PartidoIdEquipo2Navigations)
                .HasForeignKey(d => d.IdEquipo2)
                .HasConstraintName("FK__PARTIDOS__id_equ__440B1D61");

            entity.HasOne(d => d.IdEstadioNavigation).WithMany(p => p.Partidos)
                .HasForeignKey(d => d.IdEstadio)
                .HasConstraintName("FK__PARTIDOS__id_est__4222D4EF");
        });

        modelBuilder.Entity<RelJugadoresEquipo>(entity =>
        {
            entity.HasKey(e => e.IdJugador).HasName("PK__REL_JUGA__75BB83E212EBF6D9");

            entity.ToTable("REL_JUGADORES_EQUIPO");

            entity.Property(e => e.IdJugador)
                .ValueGeneratedNever()
                .HasColumnName("id_jugador");
            entity.Property(e => e.IdEquipo).HasColumnName("id_equipo");

            entity.HasOne(d => d.IdEquipoNavigation).WithMany(p => p.RelJugadoresEquipos)
                .HasForeignKey(d => d.IdEquipo)
                .HasConstraintName("FK__REL_JUGAD__id_eq__3D5E1FD2");

            entity.HasOne(d => d.IdJugadorNavigation).WithOne(p => p.RelJugadoresEquipo)
                .HasForeignKey<RelJugadoresEquipo>(d => d.IdJugador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__REL_JUGAD__id_ju__3C69FB99");
        });

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RESULTAD__3213E83F54C06CD7");

            entity.ToTable("RESULTADOS", tb => tb.HasTrigger("TRG_ACTUALIZAR_PUNTUACION"));

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPartido).HasColumnName("id_partido");
            entity.Property(e => e.ScoreEquipo1).HasColumnName("score_equipo_1");
            entity.Property(e => e.ScoreEquipo2).HasColumnName("score_equipo_2");

            entity.HasOne(d => d.IdPartidoNavigation).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.IdPartido)
                .HasConstraintName("FK__RESULTADO__id_pa__46E78A0C");
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VIDEOS__3213E83FA855FA0C");

            entity.ToTable("VIDEOS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPartido).HasColumnName("id_partido");
            entity.Property(e => e.TituloVideo)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("titulo_video");
            entity.Property(e => e.UrlVideo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("url_video");

            entity.HasOne(d => d.IdPartidoNavigation).WithMany(p => p.Videos)
                .HasForeignKey(d => d.IdPartido)
                .HasConstraintName("FK__VIDEOS__id_parti__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
