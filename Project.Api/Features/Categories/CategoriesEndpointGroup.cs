using Project.Api.Common;
using Project.Api.Extensions;
using Project.Api.Features.Categories.Endpoints;

namespace Project.Api.Features.Categories;

public class CategoriesEndpointGroup : IEndpointGroup
{
    public static string BasePath => "/api/categories";
    
    public static string[] Tags => new[] { "Categories" };

    public static void ConfigureEndpoints(RouteGroupBuilder builder)
    {
        builder
            .MapMinimalEndpoint<GetAllEndpoint>();
    }
}