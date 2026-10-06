using MediatR;
using ShopApp.Application.Common.Models;
using ShopApp.Application.Products.Dtos;


namespace ShopApp.Application.Products.Queries.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IRequest<Result<ProductDto>>;