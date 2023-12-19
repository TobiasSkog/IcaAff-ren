using Microsoft.EntityFrameworkCore;

namespace IcaAffären.Models;

public partial class IcaAffärenContext : DbContext
{
    public IcaAffärenContext()
    {
    }

    public IcaAffärenContext(DbContextOptions<IcaAffärenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Avdelning> Avdelnings { get; set; }

    public virtual DbSet<Butik> Butiks { get; set; }

    public virtual DbSet<ButiksAvdelningar> ButiksAvdelningars { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<PersonalAvdelningar> PersonalAvdelningars { get; set; }

    public virtual DbSet<PersonalRoller> PersonalRollers { get; set; }

    public virtual DbSet<Roll> Rolls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BURKEN;Database=IcaAffären;Trusted_Connection=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Avdelning>(entity =>
        {
            entity.HasKey(e => e.AvdelningsId);

            entity.ToTable("Avdelning");

            entity.Property(e => e.AvdelningsNamn).HasMaxLength(50);
        });

        modelBuilder.Entity<Butik>(entity =>
        {
            entity.ToTable("Butik");

            entity.Property(e => e.ButikAdress).HasMaxLength(50);
            entity.Property(e => e.ButikNamn).HasMaxLength(50);
            entity.Property(e => e.ButikTelefon)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ButiksAvdelningar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ButiksAvdelningar");

            entity.Property(e => e.FkAvdelningId).HasColumnName("FK_AvdelningId");
            entity.Property(e => e.FkButikId).HasColumnName("FK_ButikId");

            entity.HasOne(d => d.FkButik).WithMany()
                .HasForeignKey(d => d.FkButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ButiksAvdelningar_Avdelning");

            entity.HasOne(d => d.FkButikNavigation).WithMany()
                .HasForeignKey(d => d.FkButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ButiksAvdelningar_Butik");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.ToTable("Personal");

            entity.Property(e => e.FkButikId).HasColumnName("FK_ButikId");
            entity.Property(e => e.Kön)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PersonalNamn).HasMaxLength(50);
            entity.Property(e => e.PersonalTelefon)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Personnummer)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.HasOne(d => d.FkButik).WithMany(p => p.Personals)
                .HasForeignKey(d => d.FkButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personal_Butik");
        });

        modelBuilder.Entity<PersonalAvdelningar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PersonalAvdelningar");

            entity.Property(e => e.FkAvdelningId).HasColumnName("FK_AvdelningId");
            entity.Property(e => e.FkPersonalId).HasColumnName("FK_PersonalId");

            entity.HasOne(d => d.FkAvdelning).WithMany()
                .HasForeignKey(d => d.FkAvdelningId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalAvdelningar_AvdelningsID");

            entity.HasOne(d => d.FkPersonal).WithMany()
                .HasForeignKey(d => d.FkPersonalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalAvdelningar_PersonalId");
        });

        modelBuilder.Entity<PersonalRoller>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PersonalRoller");

            entity.Property(e => e.FkPersonalId).HasColumnName("FK_PersonalId");
            entity.Property(e => e.FkRollId).HasColumnName("FK_RollId");

            entity.HasOne(d => d.FkPersonal).WithMany()
                .HasForeignKey(d => d.FkPersonalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalRoller_Personal");

            entity.HasOne(d => d.FkRoll).WithMany()
                .HasForeignKey(d => d.FkRollId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonalRoller_Roll");
        });

        modelBuilder.Entity<Roll>(entity =>
        {
            entity.ToTable("Roll");

            entity.Property(e => e.RollNamn).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
