using System;
using System.Collections.Generic;
using FindMeJob.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FindMeJob.DOMAIN.Infrastructure.Data;

public partial class FMJDbContext : DbContext
{
    public FMJDbContext()
    {
    }

    public FMJDbContext(DbContextOptions<FMJDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<OfertaTrabajo> OfertaTrabajos { get; set; }

    public virtual DbSet<PerfilProfesional> PerfilProfesionals { get; set; }

    public virtual DbSet<Postulacion> Postulacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-UC86M417\\SQLEXPRESS;Database=FindMeJob;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresa__3213E83FDC17E6FF");

            entity.ToTable("Empresa");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<OfertaTrabajo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OfertaTr__3213E83F878B9625");

            entity.ToTable("OfertaTrabajo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("date")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Empresa).WithMany(p => p.OfertaTrabajos)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__OfertaTra__empre__60A75C0F");
        });

        modelBuilder.Entity<PerfilProfesional>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PerfilPr__3213E83FF746A581");

            entity.ToTable("PerfilProfesional");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.PerfilProfesionals)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__PerfilPro__usuar__6754599E");
        });

        modelBuilder.Entity<Postulacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Postulac__3213E83FB4D8F735");

            entity.ToTable("Postulacion");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaPostulacion)
                .HasColumnType("date")
                .HasColumnName("fecha_postulacion");
            entity.Property(e => e.OfertaId).HasColumnName("oferta_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Oferta).WithMany(p => p.Postulacions)
                .HasForeignKey(d => d.OfertaId)
                .HasConstraintName("FK__Postulaci__ofert__6477ECF3");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Postulacions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Postulaci__usuar__6383C8BA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FF20368FF");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
