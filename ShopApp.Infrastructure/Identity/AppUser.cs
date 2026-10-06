using Microsoft.AspNetCore.Identity;
using ShopApp.Domain.Entities;


namespace ShopApp.Infrastructure.Identity;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public List<RefreshToken> RefreshTokens { get; set; } = [];

}
