using ECommerce.Data.Repositories;
using ECommerce.Entities;
using ErrorOr;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.UseCases.Products.Commands.CreateProductCommand
{
    public static class CreateProductCommand
    {
        private static ProductRepository _productRepository;

        static CreateProductCommand()
        {
            _productRepository = App.AppHost.Services.GetService<ProductRepository>();
        }

        public static async Task<ErrorOr<Product>> Handle(CreateProductRequest request)
        {
            var priceConverted = decimal.TryParse(request.Price, out decimal price);

            if (!priceConverted)
            {
                return Error.Failure(
                    code: "CreateProductCommand.PriceConvert",
                    description: "Не верный формат в поле \"Цена\".");
            }

            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = price,
                Category = request.Category
            };

            await _productRepository.AddProductAsync(product);

            var saveResult = await _productRepository.CommitChangesAsync();

            if (saveResult < 1)
            {
                return Error.Failure(
                        code: "CreateProductCommand.SaveChangesError",
                        description: "Во время сохранения нового товара произошла ошибка.");
            }

            return product;
        }
    }
}
