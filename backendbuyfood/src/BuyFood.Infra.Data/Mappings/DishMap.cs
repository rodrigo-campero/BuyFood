using BuyFood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BuyFood.Infra.Data.Mappings
{
    public class DishMap : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(c => c.DishId);
            builder.Property(d => d.Price).IsRequired().HasColumnType("money");
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
        }
    }
}
