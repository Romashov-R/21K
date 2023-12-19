using ECommerce.Entities;

namespace ECommerce.UseCases.Products.Commands.CreateProductCommand
{
    public record CreateProductRequest(
        string Name,
        string Description,
        string Price,
        Category Category
    );
}
