using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopApp.Application.Auth;
using ShopApp.Application.Common.Errors;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Data;
using ShopApp.Infrastructure.Identity;
using System.Security.Cryptography;

namespace ShopApp.Infrastructure.Services;

public class AuthService(
    IJwtProvider jwtProvider,
    AppDbContext context,
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    IOptions<JwtOptions> jwtOptions) : IAuthService
{
    private readonly int refreshTokenExpiryDays = jwtOptions.Value.RefreshTokenExpiryDays;

    public async Task<Result<AuthResponse>> LoginAsync(
        string email, string password, CancellationToken ct)
    {

        var user = await userManager.FindByEmailAsync(email);
        if (user is null)
            return Result.Failure<AuthResponse>(UserError.InvalidCredentials);

        var result = await signInManager.PasswordSignInAsync(user, password,  false,false);
        if (!result.Succeeded)
            return Result.Failure<AuthResponse>(UserError.InvalidCredentials);

        return Result.Success(await IssueTokensAsync(user));
    }

    public async Task<Result<AuthResponse>> RefreshTokenAsync(string token, string refreshToken, CancellationToken ct)
    {
        var userId = jwtProvider.ValidateToken(token);
        if (userId is null) return Result.Failure<AuthResponse>(UserError.InvalidToken);

        var user = await context.Users
                        .Include(x => x.RefreshTokens)
                        .SingleOrDefaultAsync(x => x.Id == userId, ct);

        if (user is null) return Result.Failure<AuthResponse>(UserError.NotFound);
        var userRefreshToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken && x.IsActive);
        if (userRefreshToken is null) return Result.Failure<AuthResponse>(UserError.InvalidRefreshToken);
        userRefreshToken.RevokedOn = DateTime.UtcNow;

        return Result.Success(await IssueTokensAsync(user));
    }

    // Generates a JWT + a new refresh token, saves the refresh token (and any pending changes on the user).
    private async Task<AuthResponse> IssueTokensAsync(AppUser user)
    {
        var (token, expiresIn) = jwtProvider.GenerateToken(user);
        var refreshToken = GenerateRefreshToken();
        var refreshTokenExpiryDate = DateTime.UtcNow.AddDays(refreshTokenExpiryDays);

        user.RefreshTokens.Add(new RefreshToken
        {
            Token = refreshToken,
            ExpiresOn = refreshTokenExpiryDate
        });
        await userManager.UpdateAsync(user);

        return new AuthResponse(
            user.Id,
            user.FullName,
            user.Email!,
            token,
            expiresIn * 60,
            refreshToken,
            refreshTokenExpiryDate);
    }

    private static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
}
