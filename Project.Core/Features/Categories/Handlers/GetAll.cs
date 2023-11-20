using FluentResults;
using Mediator;
using Project.Core.Features.Categories.Models;

namespace Project.Core.Features.Categories.Handlers.GetAll;

public record Query : IRequest<Result<IEnumerable<Category>>>;

public class Handler : IRequestHandler<Query, Result<IEnumerable<Category>>>
{
    private readonly ICategoriesService _service;

    public Handler(ICategoriesService service)
    {
        _service = service;
    }
    
    public async ValueTask<Result<IEnumerable<Category>>> Handle(Query request, CancellationToken cancellationToken)
    {
        var categories = await _service.GetAll(cancellationToken);
        return Result.Ok(categories);
    }
}