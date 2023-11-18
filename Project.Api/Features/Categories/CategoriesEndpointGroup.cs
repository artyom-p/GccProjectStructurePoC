using Project.Api.Common;
using Project.Api.Extensions;

namespace Project.Api.Features.Categories;

public class CategoriesEndpointGroup : IEndpointGroup
{
    public static string BasePath => "/api/categories";
    
    public static string[] Tags => new[] { "Categories" };

    public static void ConfigureEndpoints(RouteGroupBuilder builder)
    {
        builder
            .MapMinimalEndpoint<Endpoints.GetAll.Endpoint>();
    }
}