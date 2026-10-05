
using MediatR;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;

namespace ShopApp.Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler(IProductService productService) : IRequestHandler<CreateProductCommand, Result>
{
    private readonly IProductService productService = productService;

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
         return  await productService.CreateProductAsync(request.Name, request.Price, cancellationToken);
    }
}
