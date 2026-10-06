using MediatR;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Auth.Commands.Login;

internal class LoginCommandHandler(IAuthService authService) : IRequestHandler<LoginCommand, Result<AuthResponse>>
{
    private readonly IAuthService authService = authService;

    public async Task<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
     return await authService.LoginAsync(request.Email, request.Password, cancellationToken);
    }
}
