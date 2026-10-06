using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Common.Errors;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Common.Models;
using ShopApp.Application.Products.Dtos;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Data;


namespace ShopApp.Infrastructure.Services;

public class ProductService(AppDbContext context) : IProductService
{
    private readonly AppDbContext context = context;

    public async Task<Result<ProductDto>> CreateProductAsync(string name, decimal price, CancellationToken cancellationToken)
    {
       var product = new Product { Name = name, Price = price };
       await context.Products.AddAsync(product, cancellationToken);
       await context.SaveChangesAsync(cancellationToken);
       var productDto = new ProductDto(product.Id, product.Name, product.Price);
       return Result.Success(productDto);
    }

    public async Task<Result<List<ProductDto>>> GetAll(CancellationToken cancellationToken)
    {
        var products = await context.Products.ToListAsync(cancellationToken);
        var productDtos = products.Select(p => new ProductDto(p.Id, p.Name, p.Price)).ToList();
        return Result.Success(productDtos);
    }

    public async Task<Result<ProductDto>> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await context.Products
                 .Where(p => p.Id == id)
                 .Select(p => new ProductDto(p.Id,p.Name,p.Price)
                  )
                 .FirstOrDefaultAsync(cancellationToken);
        if (product == null)
            return Result.Failure<ProductDto>(ProductErrors.NotFound);

        return Result.Success(product);

    }
}
