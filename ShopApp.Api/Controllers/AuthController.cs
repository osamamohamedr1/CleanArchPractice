using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Api.Extensions;
using ShopApp.Application.Auth.Commands.Login;
using ShopApp.Application.Auth.Commands.RefreshTokens;

namespace ShopApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(ISender sender) : ControllerBase
{
    private readonly ISender sender = sender;


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await sender.Send(command);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var result = await sender.Send(command);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}
