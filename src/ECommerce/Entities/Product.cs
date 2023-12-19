using ECommerce.Primitives;
using ReactiveUI;

namespace ECommerce.Entities
{
    public sealed class Product : Entity<Guid>
    {
        private string _name;
        private string _description;
        private decimal _price;
        private Category _category;
        private Guid _categoryId;

        public Product() 
        {
            Id = Guid.NewGuid();
        }

        public string Name 
        { 
            get => _name; 
            set => _name = value; 
        }

        public string Description 
        { 
            get => _description;
            set => _description = value; 
        }

        public decimal Price 
        { 
            get => _price;
            set => _price = value; 
        }

        public Guid CategoryId
        {
            get => _categoryId;
            set => _categoryId = value;
        }

        public Category Category
        {
            get => _category;
            set => _category = value;
        }
    }
}
