using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dream_Theater_Fan_Page.Models;

public partial class DreamTheaterFanPageContext : DbContext
{
    public DreamTheaterFanPageContext()
    {
    }

    public DreamTheaterFanPageContext(DbContextOptions<DreamTheaterFanPageContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Banda> Banda { get; set; }

    public virtual DbSet<Integrante> Integrantes { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banda>(entity =>
        {
            entity.HasKey(e => e.BandaId);

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Integrante>(entity =>
        {
            entity.HasKey(e => e.IntegranteId);
            entity.ToTable("Integrante");

            entity.Property(e => e.Biografia)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Instrumento)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Banda).WithMany(p => p.Integrantes)
                .HasForeignKey(d => d.BandaId)
                .HasConstraintName("FK_Integrante_Banda");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Producto");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
