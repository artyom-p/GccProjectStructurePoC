using Project.Core.Features.Categories.Models;

namespace Project.Core.Features.Categories;

public interface ICategoriesRepository
{
    Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken);
}