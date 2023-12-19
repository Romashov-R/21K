using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Repositories;

public class ProductRepository
{
    private IApplicationDbContext _context;

    public ProductRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public ICollection<Product> GetProducts()
    {
        return _context
            .Products
            .Include(product => product.Category)
            .ToList();
    }

    public async Task<ICollection<Product>> GetProductsAsync()
    {
        return await _context
            .Products
            .Include(product => product.Category)
            .ToListAsync();
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        return await _context
            .Products
            .Include(product => product.Category)
            .Where(product => product.Id == id)
            .SingleOrDefaultAsync();
    }

    public async Task AddProductAsync(Product product)
    {
        await _context
            .Products
            .AddAsync(product);
    }

    public void UpdateProduct(Product product)
    {
        _context
            .Products
            .Update(product);
    }

    public void RemoveProduct(Product product)
    {
        _context
            .Products
            .Remove(product);
    }

    public async Task<int> CommitChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
