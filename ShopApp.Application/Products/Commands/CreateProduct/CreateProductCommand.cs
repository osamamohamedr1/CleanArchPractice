
using MediatR;
using ShopApp.Application.Common.Models;

namespace ShopApp.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(
    string Name,
    decimal Price) : IRequest<Result>;
