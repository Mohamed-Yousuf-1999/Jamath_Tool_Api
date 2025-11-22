using Administration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Administration.Infrastructure.Persistence;

public partial class AdministrationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AdministrationDbContext()
    {
    }

    public AdministrationDbContext(DbContextOptions<AdministrationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jamathmember> Jamathmembers { get; set; }

    public virtual DbSet<Jamathperiod> Jamathperiods { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(_configuration.GetConnectionString("AdministrationConnection"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.43-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Jamathmember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("jamathmember")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.MemberId, "FK_JamathMember_Contributor");

            entity.HasIndex(e => e.JamathId, "FK_JamathMember_JamathPeriod");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
        });

        modelBuilder.Entity<Jamathperiod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("jamathperiods")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.ToDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("users")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.FatherId, "FK_Contributor_Father");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.BloodGroup).HasMaxLength(10);
            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.FamilyName).HasMaxLength(100);
            entity.Property(e => e.FatherName).HasMaxLength(100);
            entity.Property(e => e.Gender)
                .HasDefaultValueSql("'Male'")
                .HasColumnType("enum('Male','Female','Other')");
            entity.Property(e => e.IsAlive)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.ModifiedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.MotherName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhotoPath).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
