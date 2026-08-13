using Microsoft.EntityFrameworkCore;

namespace ASPRendezveny.Models;

public partial class RendezvenyContext : DbContext
{
    public RendezvenyContext()
    {
    }

    public RendezvenyContext(DbContextOptions<RendezvenyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Rendezveny> Rendezvenies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Rendezveny>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rendezveny");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Elnevezes)
                .HasMaxLength(100)
                .HasColumnName("elnevezes");
            entity.Property(e => e.Idopont)
                .HasColumnType("datetime")
                .HasColumnName("idopont");
            entity.Property(e => e.ResztvevokSzama).HasColumnName("resztvevok_szama");
            entity.Property(e => e.Torolt).HasColumnName("torolt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
