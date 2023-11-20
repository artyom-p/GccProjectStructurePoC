using Project.Core.Features.Categories.Models;

namespace Project.Core.Features.Categories;

public interface ICategoriesService
{
    Task<IEnumerable<Category>> GetAll(CancellationToken cancellationToken);
}