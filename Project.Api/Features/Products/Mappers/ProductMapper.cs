using Project.Api.Features.Products.Models;
using Project.Core.Features.Products.Models;

namespace Project.Api.Features.Products.Mappers;

public static class ProductMapper
{
    public static ProductResponse ToResponse(this Product product)
    {
        return new ProductResponse(product.Id, product.Name);
    }
}