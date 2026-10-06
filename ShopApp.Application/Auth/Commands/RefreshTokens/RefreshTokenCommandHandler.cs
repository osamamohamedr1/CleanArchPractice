using MediatR;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Auth.Commands.RefreshTokens;

internal class RefreshTokenCommandHandler(IAuthService authService) : IRequestHandler<RefreshTokenCommand, Result<AuthResponse>>
{
    public async Task<Result<AuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
     
        return await authService.RefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
    }
}
