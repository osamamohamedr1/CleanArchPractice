using ShopApp.Application.Common.Models;
using ShopApp.Application.Products.Dtos;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Common.Interfaces;

public interface IProductService
{
    Task<Result<ProductDto>> CreateProductAsync(string name, decimal price, CancellationToken cancellationToken);
    Task<Result<List<ProductDto>>> GetAll(CancellationToken cancellationToken);
    Task<Result<ProductDto>> GetAsync(Guid id, CancellationToken cancellationToken);
}
