using MediatR;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using ShopApp.Application.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Products.Queries.GetProducts;

internal class GetProductsQueryHandler(IProductService productService) : IRequestHandler<GetProductsQuery, Result<List<ProductDto>>>
{
    private readonly IProductService productService = productService;

    public async Task<Result<List<ProductDto>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
      return await productService.GetAll(cancellationToken);
        
    }
}
