using FluentResults;
using Mediator;
using Project.Core.Errors;
using Project.Core.Features.Products.Models;

namespace Project.Core.Features.Products.Handlers.Create;

public record Command(string Name) : IRequest<Result<Product>>;

public class Handler : IRequestHandler<Command, Result<Product>>
{
    private readonly IProductsService _service;

    public Handler(IProductsService service)
    {
        _service = service;
    }
    
    public async ValueTask<Result<Product>> Handle(Command request, CancellationToken cancellationToken)
    {
        var product = await _service.FindByName(request.Name, cancellationToken);
        if (product is not null)
        {
            return Result
                .Fail($"Product with name '{request.Name}' already exists")
                .WithError<ValidationError>();
        }
        
        product = new Product
        {
            Name = request.Name
        };
        product = await _service.Create(product, cancellationToken);
        
        return Result.Ok(product)
            .WithSuccess($"Product with name '{request.Name}' successfully created");
    }
}