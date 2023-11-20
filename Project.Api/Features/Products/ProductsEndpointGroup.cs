using Project.Api.Common;
using Project.Api.Extensions;
using Project.Api.Features.Products.Endpoints;

namespace Project.Api.Features.Products;

public class ProductsEndpointGroup : IEndpointGroup
{
    public static string BasePath => "/api/products";
    
    public static string[] Tags => new[] { "Products" };

    public static void ConfigureEndpoints(RouteGroupBuilder builder)
    {
        builder
            .MapMinimalEndpoint<GetByIdEndpoint>()
            .MapMinimalEndpoint<CreateEndpoint>();
    }
}