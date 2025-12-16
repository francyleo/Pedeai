using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedeai.App.Auth.Entities;

namespace Pedeai.App.Shared.Infra.Persistence.Configurations
{  
  public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
  {
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
      builder.ToTable("Users");

      builder.HasKey(user => user.Id);
      builder.HasIndex(user => user.Id).IsUnique();
      builder.Property(user => user.Id)
        .HasColumnType("varchar")
        .IsRequired()        
        .HasMaxLength(36);


      builder.Property(user => user.Name)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(255);  

      builder.Property(user => user.Email)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(255);
      builder.HasIndex(user => user.Email)
        .IsUnique();

      builder.Property(user => user.Password)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(255);

      builder.Property(user => user.CreatedAt)
        .HasColumnType("datetime")
        .IsRequired();

      builder.Property(user => user.UpdatedAt)
        .HasColumnType("datetime")
        .IsRequired();

      builder.Property(user => user.DeletedAt)
        .HasColumnType("datetime")
        .IsRequired(false);
    }
  }
}
