using ShopApp.Application.Auth;
using ShopApp.Application.Common.Models;


namespace ShopApp.Application.Common.Interfaces;

public interface IAuthService
{
    Task<Result<AuthResponse>> LoginAsync(string email, string password, CancellationToken ct);
}