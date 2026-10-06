namespace ShopApp.Infrastructure.Identity;

public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(AppUser user);
}
