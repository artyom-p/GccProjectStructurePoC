using FluentResults;
using Mediator;
using Project.Core.Features.Products.Models;

namespace Project.Core.Features.Products.Handlers.GetById;

public record Query(Guid Id) : IRequest<Result<Product?>>;

public class Handler : IRequestHandler<Query, Result<Product?>>
{
    private readonly IProductsRepository _repository;

    public Handler(IProductsRepository repository)
    {
        _repository = repository;
    }
    
    public async ValueTask<Result<Product?>> Handle(Query request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id, cancellationToken);
        return Result.Ok(product);
    }
}