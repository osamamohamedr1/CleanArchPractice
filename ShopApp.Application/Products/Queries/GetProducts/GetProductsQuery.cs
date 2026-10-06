using MediatR;
using ShopApp.Application.Common.Models;
using ShopApp.Application.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopApp.Application.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<Result<List<ProductDto>>>
{
}
