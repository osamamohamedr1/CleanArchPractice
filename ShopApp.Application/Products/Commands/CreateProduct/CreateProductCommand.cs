
using MediatR;
using ShopApp.Application.Common.Models;
using ShopApp.Application.Products.Dtos;

namespace ShopApp.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    decimal Price) : IRequest<Result<ProductDto>>;
