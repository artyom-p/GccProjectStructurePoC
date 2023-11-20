using FluentValidation;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Common;
using Project.Api.Extensions;
using Project.Api.Features.Products.Mappers;
using Project.Api.Features.Products.Models;
using Project.Core.Errors;
using Project.Core.Features.Products.Handlers.Create;

namespace Project.Api.Features.Products.Endpoints;

public class CreateEndpoint : IEndpoint
{
    public const string Name = "Products.Create";

    public static IEndpointConventionBuilder Map(IEndpointRouteBuilder builder)
    {
        return builder
            .MapPost("", Handle)
            .WithName(Name)
            .WithSummary("Create new product")
            .AllowAnonymous();
    }

    private static async Task<Results<CreatedAtRoute<ProductResponse>, ValidationProblem>> Handle(
        [FromBody] Request request,
        [FromServices] IValidator<Request> validator,
        [FromServices] IMediator mediator,
        CancellationToken ct)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        if (!validationResult.IsValid)
        {
            return validationResult.ToValidationProblem();
        }
        
        var query = new Command(request.Name);
        var result = await mediator.Send(query, ct);
        
        if (result.HasError<ValidationError>())
        {
            return result.ToValidationProblem();   
        }
        
        var payload = result.Value.ToResponse();
        return TypedResults
            .CreatedAtRoute(payload, GetByIdEndpoint.Name, new { id = payload.Id });
    }
    
    public record Request
    {
        public required string Name { get; init; }
    }

    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}