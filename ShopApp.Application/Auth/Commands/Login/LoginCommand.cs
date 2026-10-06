using MediatR;
using ShopApp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Auth.Commands.Login;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<Result<AuthResponse>>;
