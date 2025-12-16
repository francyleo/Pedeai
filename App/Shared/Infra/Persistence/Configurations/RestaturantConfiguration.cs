using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedeai.App.Catalog.Restaurants.Entities;

namespace Pedeai.App.Shared.Infra.Persistence.Configurations
{  
  public class RestaurantConfiguration : IEntityTypeConfiguration<RestaurantEntity>
  {
    public void Configure(EntityTypeBuilder<RestaurantEntity> builder)
    {
      builder.ToTable("Restaurants");
      builder.HasKey(restaurant => restaurant.Id);
      builder.HasIndex(restaurant => restaurant.Id).IsUnique();
      builder.Property(restaurant => restaurant.Id)
        .HasColumnType("varchar")
        .IsRequired()        
        .HasMaxLength(36);

      builder.Property(restaurant => restaurant.Name)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(255);     

      builder.Property(restaurant => restaurant.FantasyName)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(255);

      builder.Property(restaurant => restaurant.Cnpj)
        .HasColumnType("varchar")
        .IsRequired()
        .HasMaxLength(14);
      builder.HasIndex(restaurant => restaurant.Cnpj)
        .IsUnique();

      builder.Property(restaurant => restaurant.CreatedAt)
        .HasColumnType("datetime")
        .IsRequired();

      builder.Property(restaurant => restaurant.UpdatedAt)
        .HasColumnType("datetime")
        .IsRequired();

      builder.Property(restaurant => restaurant.DeletedAt)
        .HasColumnType("datetime")
        .IsRequired(false);
    }
  }
}
