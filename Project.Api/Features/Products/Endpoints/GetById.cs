using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Common;
using Project.Api.Features.Products.Mappers;
using Project.Api.Features.Products.Models;
using Project.Core.Errors;
using Project.Core.Features.Products.Handlers.GetById;

namespace Project.Api.Features.Products.Endpoints.GetById;

public record Request(Guid Id);

public class Endpoint : IEndpoint
{
    public const string Name = "Products.GetById";

    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder
            .MapGet("{id:guid}", Handle)
            .WithName(Name)
            .WithSummary("Get product by id")
            .AllowAnonymous();
    }

    private static async Task<Results<Ok<ProductResponse>, NotFound>> Handle(
        [AsParameters] Request request,
        [FromServices] IMediator mediator,
        CancellationToken ct)
    {
        var query = new Query(request.Id);
        var result = await mediator.Send(query, ct);

        if (result.HasError<NotFoundError>())
        {
            return TypedResults.NotFound();
        }

        var payload = result.Value.ToResponse();
        return TypedResults.Ok(payload);
    }
}