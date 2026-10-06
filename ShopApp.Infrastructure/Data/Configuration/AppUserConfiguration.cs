using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Infrastructure.Identity;

namespace ShopApp.Infrastructure.Data.Configuration;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    private const string DefaultUserId = "b6f3c1e2-5d7a-4c0e-9a41-2f8d1c7e9a10";

    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.FullName).HasMaxLength(100);

        // Dev seed user: admin@shop.com / Admin@123 (change the password outside development)
        builder.HasData(new AppUser
        {
            Id = DefaultUserId,
            FullName = "Admin",
            UserName = "admin@shop.com",
            NormalizedUserName = "ADMIN@SHOP.COM",
            Email = "admin@shop.com",
            NormalizedEmail = "ADMIN@SHOP.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEF5ub6LLJt183v7JgwCK7JpSANO1uP/6A10/43G6nhVOytd9im2fHIPwnUTKdAOmcA==",
            SecurityStamp = "7d1b6a52-3f0e-4a9c-8b21-5e6c4d3f2a11",
            ConcurrencyStamp = "c3a9e8d4-1b7f-4e52-9d06-8a2f5b7c1e33",
            LockoutEnabled = true
        });
    }
}
