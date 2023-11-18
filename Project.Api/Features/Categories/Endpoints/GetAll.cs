using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Common;
using Project.Api.Features.Categories.Mappers;
using Project.Api.Features.Categories.Models;
using Project.Core.Features.Categories.Handlers.GetAll;

namespace Project.Api.Features.Categories.Endpoints.GetAll;

public class Endpoint : IEndpoint
{
    public const string Name = "Categories.GetAll";

    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder
            .MapGet("", Handle)
            .WithName(Name)
            .WithSummary("Get categories")
            .AllowAnonymous();
    }
    
    private static async Task<Results<Ok<List<CategoryResponse>>, BadRequest>> Handle(
        [FromServices] IMediator mediator,
        CancellationToken ct)
    {
        var query = new Query();
        var result = await mediator.Send(query, ct);
        if (result.IsFailed)
        {
            return TypedResults.BadRequest();
        }
        
        var payload = result.Value
            .Select(c => c.ToResponse())
            .ToList();
        
        return TypedResults.Ok(payload);
    }
}