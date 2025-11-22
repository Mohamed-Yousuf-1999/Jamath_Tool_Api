using Administration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Administration.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Gender).HasMaxLength(10).HasDefaultValue("Male");
            builder.Property(u => u.PhotoPath).HasMaxLength(250);

            builder.HasMany(u => u.Jamathmembers)
                .WithOne(jm => jm.User)
                .HasForeignKey(jm => jm.MemberId);
        }
    }
}
