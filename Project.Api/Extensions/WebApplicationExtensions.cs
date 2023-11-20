using Project.Api.Common;
using Project.Api.Features.Categories;
using Project.Api.Features.Products;

namespace Project.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseProblemDetailsExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async httpContext =>
            {
                var problemDetailsService = httpContext.RequestServices.GetService<IProblemDetailsService>();
                
                if (problemDetailsService == null || 
                    !await problemDetailsService.TryWriteAsync(new ProblemDetailsContext { HttpContext = httpContext }))
                {
                    await httpContext.Response.WriteAsync("An error occurred while processing your request.");
                }
            });
        });
        
        return app;
    }
    
    public static WebApplication MapGccEndpoints(this WebApplication app)
    {
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