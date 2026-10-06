using Microsoft.AspNetCore.Identity;
using ShopApp.Application.Auth;
using ShopApp.Application.Common.Errors;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using ShopApp.Infrastructure.Identity;

namespace ShopApp.Infrastructure.Services;

public class AuthService(
    IJwtProvider jwtProvider,
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager) : IAuthService
{

    public async Task<Result<AuthResponse>> LoginAsync(
        string email, string password, CancellationToken ct)
    {

        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
            return Result.Failure<AuthResponse>(UserError.InvalidCredentials);

        var result = await signInManager.PasswordSignInAsync(user, password,  false,false);
        if (result.Succeeded)
        {
            var (token, expiresIn) = jwtProvider.GenerateToken(user);
            //var refreshToken = GenerateRefreshToken();
            //user.RefreshTokens.Add(new RefreshToken
            //{
            //    Token = refreshToken,
            //    ExpiresOn = refreshTokenExpiresOn
            //});
            //await userManager.UpdateAsync(user);

            return Result.Success(new AuthResponse(
                user.Id,
                user.FullName,
                user.Email!,
                token,
                expiresIn * 60));
        }
        return Result.Failure<AuthResponse>(UserError.InvalidCredentials);
    }
}
