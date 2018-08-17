using BuyFood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BuyFood.Infra.Data.Mappings
{
    public class RestaurantMap : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(c => c.RestaurantId);
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.HasMany(r => r.Dishes).WithOne(d => d.Restaurant).HasForeignKey(d => d.RestaurantId);
        }
    }
}
