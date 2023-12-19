using ECommerce.Data.Repositories;
using ECommerce.Entities;
using ECommerce.Primitives;
using ECommerce.UseCases.Products.Commands.CreateProductCommand;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System.Reactive;

namespace ECommerce.ViewModels
{
    public class AddProductViewModel : ViewModel
    {
        private CategoryRepository _categoryRepository;

        private string _name;
        private string _description;
        private string _price;
        private Category _selectedCategory;
        private ICollection<Category> _categories;

        public event EventHandler<Product> ProductAdded;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public string Price
        {
            get => _price;
            set => this.RaiseAndSetIfChanged(ref _price, value);
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set => this.RaiseAndSetIfChanged(ref _selectedCategory, value);
        }

        public ICollection<Category> Categories
        {
            get => _categories;
            set => this.RaiseAndSetIfChanged(ref _categories, value);
        }

        public AddProductViewModel()
        {
            // Внедрение зависимостей
            _categoryRepository = App.AppHost.Services.GetService<CategoryRepository>();

            InitializeState();
        }

        private void InitializeState()
        {
            _categories = _categoryRepository.GetCategories();
        }

        public ReactiveCommand<Unit, Unit> AddProductCommand =>
            ReactiveCommand.CreateFromTask(async () =>
            {
                CreateProductRequest request = new CreateProductRequest(
                    _name,
                    _description,
                    _price,
                    _selectedCategory
                );

                var result = await CreateProductCommand.Handle(request);

                if (!result.IsError)
                {
                    ProductAdded?.Invoke(this, result.Value);
                }
            });
    }
}
