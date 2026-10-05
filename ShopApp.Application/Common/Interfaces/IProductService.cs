using ShopApp.Application.Common.Models;

namespace ShopApp.Application.Common.Interfaces;

public interface IProductService
{
    Task<Result> CreateProductAsync(string name, decimal price, CancellationToken cancellationToken);
}
