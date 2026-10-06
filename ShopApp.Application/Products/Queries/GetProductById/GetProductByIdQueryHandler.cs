using MediatR;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using ShopApp.Application.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Products.Queries.GetProductById;

public class GetProductByIdQueryHandler(IProductService productService) : IRequestHandler<GetProductByIdQuery,Result<ProductDto>>
{
    private readonly IProductService productService = productService;

    public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await productService.GetAsync(request.Id, cancellationToken);
    }
}
