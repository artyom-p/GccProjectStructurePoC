namespace Project.Core.Features.Products.Models;

public record Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
}