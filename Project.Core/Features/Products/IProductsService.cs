using Project.Core.Features.Products.Models;

namespace Project.Core.Features.Products;

public interface IProductsService
{
    Task<Product?> GetById(Guid id, CancellationToken ct = default);
   
    Task<Product?> FindByName(string name, CancellationToken ct = default);
    
    Task<Product> Create(Product product, CancellationToken ct = default);
}