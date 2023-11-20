using Project.Core.Features.Products;
using Project.Core.Features.Products.Models;

namespace ImplementationA.Services;

public class ProductsService : IProductsService
{
    public async Task<Product?> GetById(Guid id, CancellationToken ct = default)
    {
        // Calls implementation API here
        
        return await Task.FromResult(new Product
        {
            Id = id,
            Name = "ProviderA Product"
        });
    }

    public async Task<Product?> FindByName(string name, CancellationToken ct = default)
    {
        return await Task.FromResult(null as Product);
    }

    public async Task<Product> Create(Product product, CancellationToken ct = default)
    {
        return await Task.FromResult(new Product
        {
            Id = Guid.NewGuid(),
            Name = product.Name
        });
    }
}