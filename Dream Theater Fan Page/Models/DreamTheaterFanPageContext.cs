using System;
using System.Collections.Generic;
using Dream_Theater_Fan_Page.Models.CarritoCompras;
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

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
