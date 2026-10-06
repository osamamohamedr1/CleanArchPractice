using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Domain.Entities;


namespace ShopApp.Infrastructure.Data.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("Products");
        builder.Property(x => x.Name).IsRequired();
        builder.Property(p => p.Price)
            .HasPrecision(18, 2);
    }
}
