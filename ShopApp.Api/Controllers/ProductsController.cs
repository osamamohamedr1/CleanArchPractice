using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Api.Extensions;
using ShopApp.Application.Products.Commands.CreateProduct;

namespace ShopApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(ISender sender) : ControllerBase
{
    private readonly ISender sender = sender;

    [HttpPost("")]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand product)
    {
        var result =   await sender.Send(product);
        return result.IsSuccess ? Created() : result.ToProblem();
    }
}
