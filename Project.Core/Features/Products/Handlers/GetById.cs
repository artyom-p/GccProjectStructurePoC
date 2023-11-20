using FluentResults;
using Mediator;
using Project.Core.Errors;
using Project.Core.Features.Products.Models;

namespace Project.Core.Features.Products.Handlers.GetById;

public record Query(Guid Id) : IRequest<Result<Product>>;

public class Handler : IRequestHandler<Query, Result<Product>>
{
    private readonly IProductsService _service;

    public Handler(IProductsService service)
    {
        _service = service;
    }
    
    public async ValueTask<Result<Product>> Handle(Query request, CancellationToken cancellationToken)
    {
        var product = await _service.GetById(request.Id, cancellationToken);
        if (product is null)
        {
            return Result
                .Fail("Product not found")
                .WithError<NotFoundError>();
        }
        
        return Result.Ok(product);
    }
}