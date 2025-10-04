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

    public DbSet<condominio> condominios { get; set; }

    public DbSet<propiedad> propiedads { get; set; }

    public DbSet<propietario> propietarios { get; set; }

    public DbSet<recibo_detalle> recibo_detalles { get; set; }

    public DbSet<recibo_encabezado> recibo_encabezados { get; set; }

    public DbSet<rubro> rubros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Name=ConnectionStrings:CondoDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<condominio>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__condomin__3213E83F48834C57");

            entity.ToTable("condominio");

            entity.HasIndex(e => e.direccion, "UQ__condomin__636D81ABC870A734").IsUnique();

            entity.HasIndex(e => e.nombre, "UQ__condomin__72AFBCC6F343611B").IsUnique();

            entity
                .Property(e => e.id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('C-'+format(NEXT VALUE FOR [seq_condominio],'000'))");
            entity.Property(e => e.direccion).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.image_condominio).HasMaxLength(500);
            entity.Property(e => e.nombre).HasMaxLength(100).IsUnicode(false);
        });

        modelBuilder.Entity<propiedad>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__propieda__3213E83F604C3451");

            entity.ToTable("propiedad");

            entity.HasIndex(e => e.avatar, "UQ__propieda__22FCF9849B7BB869").IsUnique();

            entity
                .Property(e => e.id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("('P-'+format(NEXT VALUE FOR [seq_propiedad],'000'))");
            entity.Property(e => e.avatar).HasMaxLength(500);
            entity.Property(e => e.direccion).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.id_condominio).HasMaxLength(5).IsUnicode(false);

            entity
                .HasOne(d => d.id_condominioNavigation)
                .WithMany(p => p.propiedads)
                .HasForeignKey(d => d.id_condominio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__propiedad__id_co__3D5E1FD2");

            entity
                .HasMany(d => d.dpi_propietarios)
                .WithMany(p => p.id_propiedads)
                .UsingEntity<Dictionary<string, object>>(
                    "propiedad_propietario",
                    r =>
                        r.HasOne<propietario>()
                            .WithMany()
                            .HasForeignKey("dpi_propietario")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__propiedad__dpi_p__46E78A0C"),
                    l =>
                        l.HasOne<propiedad>()
                            .WithMany()
                            .HasForeignKey("id_propiedad")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK__propiedad__id_pr__45F365D3"),
                    j =>
                    {
                        j.HasKey("id_propiedad", "dpi_propietario")
                            .HasName("pk_propiedad_propietario");
                        j.ToTable("propiedad_propietario");
                        j.IndexerProperty<string>("id_propiedad").HasMaxLength(5).IsUnicode(false);
                        j.IndexerProperty<string>("dpi_propietario")
                            .HasMaxLength(13)
                            .IsUnicode(false);
                    }
                );
        });

        modelBuilder.Entity<propietario>(entity =>
        {
            entity.HasKey(e => e.dpi).HasName("PK__propieta__D87619646742879D");

            entity.ToTable("propietario");

            entity.HasIndex(e => e.nit, "UQ__propieta__DF97D0E4D099E629").IsUnique();

            entity.Property(e => e.dpi).HasMaxLength(13).IsUnicode(false);
            entity.Property(e => e.apellido).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.estado).HasDefaultValue(true);
            entity.Property(e => e.nit).HasMaxLength(13).IsUnicode(false);
            entity.Property(e => e.nombre).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.prefijo_pais).HasMaxLength(5).IsUnicode(false);
            entity.Property(e => e.telefono).HasMaxLength(20).IsUnicode(false);
        });

        modelBuilder.Entity<recibo_detalle>(entity =>
        {
            entity.HasKey(e => new { e.num_rec, e.id_rubro }).HasName("pk_recibo_detalle");

            entity.ToTable(
                "recibo_detalle",
                tb =>
                {
                    tb.HasTrigger("trg_no_update_cuota_recibo_detalle");
                    tb.HasTrigger("trg_set_cuota_recibo_detalle");
                }
            );

            entity.Property(e => e.num_rec).HasMaxLength(8).IsUnicode(false);
            entity.Property(e => e.cuota).HasColumnType("decimal(10, 2)");

            entity
                .HasOne(d => d.id_rubroNavigation)
                .WithMany(p => p.recibo_detalles)
                .HasForeignKey(d => d.id_rubro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_de__id_ru__5812160E");

            entity
                .HasOne(d => d.num_recNavigation)
                .WithMany(p => p.recibo_detalles)
                .HasForeignKey(d => d.num_rec)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_de__num_r__59063A47");
        });

        modelBuilder.Entity<recibo_encabezado>(entity =>
        {
            entity.HasKey(e => e.num_rec).HasName("PK__recibo_e__C0853F74934AD73C");

            entity.ToTable("recibo_encabezado");

            entity.Property(e => e.num_rec).HasMaxLength(8).IsUnicode(false);
            entity.Property(e => e.dpi_propietario).HasMaxLength(13).IsUnicode(false);
            entity.Property(e => e.fecha_recibo).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.id_propiedad).HasMaxLength(5).IsUnicode(false);

            entity
                .HasOne(d => d.dpi_propietarioNavigation)
                .WithMany(p => p.recibo_encabezados)
                .HasForeignKey(d => d.dpi_propietario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_en__dpi_p__4BAC3F29");

            entity
                .HasOne(d => d.id_propiedadNavigation)
                .WithMany(p => p.recibo_encabezados)
                .HasForeignKey(d => d.id_propiedad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__recibo_en__id_pr__4AB81AF0");
        });

        modelBuilder.Entity<rubro>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__rubro__3213E83FF42E2A10");

            entity.ToTable("rubro");

            entity.HasIndex(e => e.nombre, "UQ__rubro__72AFBCC672BC12CD").IsUnique();

            entity.Property(e => e.cuota).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.nombre).HasMaxLength(60).IsUnicode(false);
        });
        modelBuilder.HasSequence("seq_condominio").HasMin(1L).HasMax(999L);
        modelBuilder.HasSequence("seq_propiedad").HasMin(1L).HasMax(999L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
