using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Auth;

public record AuthResponse
(
    string Id,
    string FullName,
    string? Email,
    string Token,
    int ExpiresIn,
    string RefreshToken,
    DateTime ExpiresInRefreshToken
    );