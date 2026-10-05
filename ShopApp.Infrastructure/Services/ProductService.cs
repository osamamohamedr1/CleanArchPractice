using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Data;


namespace ShopApp.Infrastructure.Services;

public class ProductService(AppDbContext context) : IProductService
{
    private readonly AppDbContext context = context;

    public async Task<Result> CreateProductAsync(string name, decimal price, CancellationToken cancellationToken)
    {
       await context.Products.AddAsync(new Product { Name = name, Price = price }, cancellationToken);
       await context.SaveChangesAsync(cancellationToken);
       return Result.Success();
    }
}
