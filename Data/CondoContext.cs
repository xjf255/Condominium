using System;
using System.Collections.Generic;
using Condominium.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Condominium.Data;

public partial class CondoContext : DbContext
{
    public CondoContext() { }

    public CondoContext(DbContextOptions<CondoContext> options)
        : base(options) { }

    public DbSet<Condominio> Condominios { get; set; }
    public DbSet<Propiedad> Propiedades { get; set; }
    public DbSet<Propietario> Propietarios { get; set; }
    public DbSet<ReciboDetalle> ReciboDetalles { get; set; }
    public DbSet<ReciboEncabezado> ReciboEncabezados { get; set; }
    public DbSet<Rubro> Rubros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Name=ConnectionStrings:CondoDb");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Condominio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__condomin__3213E83F48834C57");

            entity.ToTable("condominio");

            entity.HasIndex(e => e.Direccion, "UQ__condomin__636D81ABC870A734").IsUnique();

            entity.HasIndex(e => e.Nombre, "UQ__condomin__72AFBCC6F343611B").IsUnique();

            entity
                .Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('C-'+format(NEXT VALUE FOR [seq_condominio],'000'))");
            entity.Property(e => e.Direccion).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.ImageCondominio).HasMaxLength(500);
            entity.Property(e => e.Nombre).HasMaxLength(100).IsUnicode(false);
        });

        modelBuilder.Entity<Propiedad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__propieda__3213E83F604C3451");

            entity.ToTable("Propiedad");

            entity.HasIndex(e => e.Avatar, "UQ__propieda__22FCF9849B7BB869").IsUnique();

            entity
                .Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('P-'+format(NEXT VALUE FOR [seq_Propiedad],'000'))");
            entity.Property(e => e.Avatar).HasMaxLength(500);
            entity.Property(e => e.Direccion).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.IdCondominio).HasMaxLength(5).IsUnicode(false);

            entity
                .HasOne(d => d.IdCondominioNavigation)
                .WithMany(p => p.Propiedads)
                .HasForeignKey(d => d.IdCondominio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Propiedad__Id_co__3D5E1FD2");

            entity
                .HasMany(d => d.DpiPropietarios)
                .WithMany(p => p.IdPropiedades)
                .UsingEntity<Dictionary<string, object>>(
                    "Propiedad_Propietario",
                    r =>
                        r.HasOne<Propietario>()
                            .WithMany()
                            .HasForeignKey("Dpi_Propietario")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Propiedad__Dpi_p__46E78A0C"),
                    l =>
                        l.HasOne<Propiedad>()
                            .WithMany()
                            .HasForeignKey("Id_Propiedad")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__Propiedad__Id_pr__45F365D3"),
                    j =>
                    {
                        j.HasKey("Id_Propiedad", "Dpi_Propietario")
                            .HasName("pk_Propiedad_Propietario");
                        j.ToTable("Propiedad_Propietario");
                        j.IndexerProperty<string>("Id_Propiedad").HasMaxLength(5).IsUnicode(false);
                        j.IndexerProperty<string>("Dpi_Propietario")
                            .HasMaxLength(13)
                            .IsUnicode(false);
                    }
                );
        });

        modelBuilder.Entity<Propietario>(entity =>
        {
            entity.HasKey(e => e.Dpi).HasName("PK__propieta__D87619646742879D");

            entity.ToTable("Propietario");

            entity.HasIndex(e => e.Nit, "UQ__propieta__DF97D0E4D099E629").IsUnique();

            entity.Property(e => e.Dpi).HasMaxLength(13).IsUnicode(false);
            entity.Property(e => e.Apellido).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Nit).HasMaxLength(13).IsUnicode(false);
            entity.Property(e => e.Nombre).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.PrefijoPais).HasMaxLength(5).IsUnicode(false);
            entity.Property(e => e.Telefono).HasMaxLength(20).IsUnicode(false);
        });

        modelBuilder.Entity<ReciboDetalle>(entity =>
        {
            entity.HasKey(e => new { e.NumRec, e.IdRubro }).HasName("pk_ReciboDetalle");

            entity.ToTable(
                "ReciboDetalle",
                tb =>
                {
                    tb.HasTrigger("trg_no_update_cuota_ReciboDetalle");
                    tb.HasTrigger("trg_set_cuota_ReciboDetalle");
                }
            );

            entity.Property(e => e.NumRec).HasMaxLength(8).IsUnicode(false);
            entity.Property(e => e.Cuota).HasColumnType("decimal(10, 2)");

            entity
                .HasOne(d => d.IdRubroNavigation)
                .WithMany(p => p.ReciboDetalles)
                .HasForeignKey(d => d.IdRubro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_de__Id_ru__5812160E");

            entity
                .HasOne(d => d.NumRecNavigation)
                .WithMany(p => p.ReciboDetalles)
                .HasForeignKey(d => d.NumRec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_de__num_r__59063A47");
        });

        modelBuilder.Entity<ReciboEncabezado>(entity =>
        {
            entity.HasKey(e => e.NumRec).HasName("PK__recibo_e__C0853F74934AD73C");

            entity.ToTable("ReciboEncabezado");

            entity.Property(e => e.NumRec).HasMaxLength(8).IsUnicode(false);
            entity.Property(e => e.DpiPropietario).HasMaxLength(13).IsUnicode(false);
            entity.Property(e => e.FechaRecibo).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IdPropiedad).HasMaxLength(5).IsUnicode(false);

            entity
                .HasOne(d => d.DpiPropietarioNavigation)
                .WithMany(p => p.ReciboEncabezados)
                .HasForeignKey(d => d.DpiPropietario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_en__Dpi_p__4BAC3F29");

            entity
                .HasOne(d => d.IdPropiedadNavigation)
                .WithMany(p => p.ReciboEncabezados)
                .HasForeignKey(d => d.IdPropiedad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_en__Id_pr__4AB81AF0");
        });

        modelBuilder.Entity<Rubro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rubro__3213E83FF42E2A10");

            entity.ToTable("Rubro");

            entity.HasIndex(e => e.Nombre, "UQ__Rubro__72AFBCC672BC12CD").IsUnique();

            entity.Property(e => e.Cuota).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Nombre).HasMaxLength(60).IsUnicode(false);
        });
        modelBuilder.HasSequence("seq_condominio").HasMin(1L).HasMax(999L);
        modelBuilder.HasSequence("seq_Propiedad").HasMin(1L).HasMax(999L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
