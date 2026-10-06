using Microsoft.AspNetCore.Identity;
using ShopApp.Application.Auth;
using ShopApp.Application.Common.Errors;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using ShopApp.Infrastructure.Data;
using ShopApp.Infrastructure.Identity;

namespace ShopApp.Infrastructure.Services;

public class AuthService(
    IJwtProvider jwtProvider,
    UserManager<AppUser> userManager) : IAuthService
{
    public async Task<Result<AuthResponse>> LoginAsync(
        string email, string password, CancellationToken ct)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
            return Result.Failure<AuthResponse>(UserError.InvalidCredentials);

        // Locked-out users get the same generic error
        if (await userManager.IsLockedOutAsync(user))
            return Result.Failure<AuthResponse>(UserError.InvalidCredentials);

        if (!await userManager.CheckPasswordAsync(user, password))
        {
            await userManager.AccessFailedAsync(user);   // counts toward lockout
            return Result.Failure<AuthResponse>(UserError.InvalidCredentials);
        }

        await userManager.ResetAccessFailedCountAsync(user);

        var (token, expiresIn) = jwtProvider.GenerateToken(user);

        return Result.Success(new AuthResponse(
            user.Id,
            user.FullName,
            user.Email!,
            token,
            expiresIn * 60));
    }
}
