using Project.Core.Features.Categories;
using Project.Core.Features.Categories.Models;

namespace ImplementationA.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    public async Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken)
    {
        return await Task.FromResult(new List<Category>
        {
            new Category("One")
        });
    }
}