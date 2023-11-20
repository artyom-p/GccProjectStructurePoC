using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using Project.Api.Common;
using Project.Api.Features.Categories;
using Project.Api.Features.Products;

namespace Project.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MapGccEndpoints(this WebApplication app)
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        app.MapGet("/swagger/v1/swagger.json", () =>
        {
            var json = File.ReadAllText($"{assemblyPath}/swagger.json");
            var doc = JsonSerializer.Deserialize<OpenApiDocument>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            doc.Info.Title = "GCC API";
            doc.Info.Version = "1.2.3";
            return Results.Json(doc);
        });
        
        app.MapEndpointGroup<ProductsEndpointGroup>();
        app.MapEndpointGroup<CategoriesEndpointGroup>();
        
        return app;
    }
    
    public static WebApplication MapEndpointGroup<TGroup>(this WebApplication app)
        where TGroup : IEndpointGroup
    {
        var group = app.MapGroup(TGroup.BasePath);

        TGroup.ConfigureEndpoints(group);

        if (TGroup.Tags.Length > 0)
        {
            group.WithTags(TGroup.Tags);
        }

        if (TGroup.OpenApiEnabled)
        {
            group.WithOpenApi();
        }

        return app;
    }
}