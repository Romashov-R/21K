using ECommerce.Data.Repositories;
using ECommerce.Entities;
using ECommerce.Primitives;
using ECommerce.View;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ECommerce.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private ProductRepository _productRepository;

        private ObservableCollection<Product> _products;
        private Product _selectedProduct;

        public ObservableCollection<Product> Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => this.RaiseAndSetIfChanged(ref _selectedProduct, value);
        }

        public MainViewModel()
        {
            // Внедрение зависимостей
            _productRepository = App.AppHost.Services.GetService<ProductRepository>();

            InitializeState();
        }

        private void InitializeState()
        {
            var products = _productRepository.GetProducts();
            _products = new ObservableCollection<Product>(products);
            SelectedProduct = _products[0];
        }

        public ReactiveCommand<Unit, Unit> OpenAddProductWindowCommand =>
            ReactiveCommand.Create(() =>
                {
                    AddProductWindow window = new AddProductWindow();
                    AddProductViewModel viewModel = (AddProductViewModel)window.DataContext;
                    viewModel.ProductAdded += (sender, product) => _products.Add(product);
                    window.ShowDialog();
                }
            );
    }
}
