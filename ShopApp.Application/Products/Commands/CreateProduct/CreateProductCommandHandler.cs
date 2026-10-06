
using MediatR;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using ShopApp.Application.Products.Dtos;

namespace ShopApp.Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler(IProductService productService) : IRequestHandler<CreateProductCommand, Result<ProductDto>>
{
    private readonly IProductService productService = productService;

    public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
         return  await productService.CreateProductAsync(request.Name, request.Price, cancellationToken);
    }
}
