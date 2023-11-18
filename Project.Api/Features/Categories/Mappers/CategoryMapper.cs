using Project.Api.Features.Categories.Models;
using Project.Core.Features.Categories.Models;

namespace Project.Api.Features.Categories.Mappers;

public static class CategoryMapper
{
    public static CategoryResponse ToResponse(this Category category)
    {
        return new CategoryResponse(category.Name);
    }
}