using MediatR;
using ShopApp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Auth.Commands.RefreshTokens;

public record RefreshTokenCommand(string Token, string RefreshToken) : IRequest<Result<AuthResponse>>;
