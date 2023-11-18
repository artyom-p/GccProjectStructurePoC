using Project.Api.Common;
using Project.Api.Extensions;

namespace Project.Api.Features.Products;

public class ProductsEndpointGroup : IEndpointGroup
{
    public static string BasePath => "/api/products";
    
    public static string[] Tags => new[] { "Products" };

    public static void ConfigureEndpoints(RouteGroupBuilder builder)
    {
        builder
            .MapMinimalEndpoint<Endpoints.GetById.Endpoint>()
            .MapMinimalEndpoint<Endpoints.Create.Endpoint>();
    }
}