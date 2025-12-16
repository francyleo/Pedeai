using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedeai.App.Auth.Entities;

namespace Pedeai.App.Auth.Infra.Persistence.Configurations
{  
  public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
  {
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
      builder.ToTable("Users");

      builder.HasKey(user => user.Id);
      builder.HasIndex(user => user.Id).IsUnique();

      builder.Property(user => user.Name)
        .IsRequired()
        .HasMaxLength(255);     

      builder.Property(user => user.Email)
        .IsRequired()
        .HasMaxLength(255);
      builder.HasIndex(user => user.Email)
        .IsUnique();

      builder.Property(user => user.Password)
        .IsRequired()
        .HasMaxLength(255);

      builder.Property(user => user.CreatedAt)
        .IsRequired();

      builder.Property(user => user.UpdatedAt)
        .IsRequired();
    }
  }
}
