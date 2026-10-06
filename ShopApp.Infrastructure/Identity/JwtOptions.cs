using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Infrastructure.Identity;

public class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; init; } = default!;
    public string Audience { get; init; } = default!;
    public string SecretKey { get; init; } = default!;
    public int ExpiryMinutes { get; init; } = 60;
}