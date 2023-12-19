using ECommerce.Primitives;
using ReactiveUI;

namespace ECommerce.Entities
{
    public sealed class Category : Entity<Guid>
    {
        private string _name;
        private ICollection<Product> _products;

        public Category()
        {
            Id = Guid.NewGuid();
        }

        public string Name 
        { 
            get => _name;
            set => _name = value;
        }

        public ICollection<Product> Products 
        { 
            get => _products; 
            set => _products = value; 
        }
    }
}
