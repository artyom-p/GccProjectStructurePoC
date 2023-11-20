using Project.Core.Features.Categories;
using Project.Core.Features.Categories.Models;

namespace ImplementationB.Api.Repositories;

public class CategoriesService : ICategoriesService
{
    public async Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken)
    {
        return await Task.FromResult(new List<Category>
        {
            new Category("One")
        });
    }
}