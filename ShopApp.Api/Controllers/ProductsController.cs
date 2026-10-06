using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Api.Extensions;
using ShopApp.Application.Products.Commands.CreateProduct;
using ShopApp.Application.Products.Queries.GetProductById;
using ShopApp.Application.Products.Queries.GetProducts;

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
        return result.IsSuccess ? Created("",result.Value) : result.ToProblem();
    }
    [HttpGet("")]
    public async Task<IActionResult> GetAllProducts()
    {
        var result =   await sender.Send(new GetProductsQuery());
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetProduct([FromRoute] Guid Id)
    {
        var result =   await sender.Send(new GetProductByIdQuery(Id));
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }
}
