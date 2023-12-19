using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Repositories;

public class CategoryRepository
{
    private IApplicationDbContext _context;

    public CategoryRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public ICollection<Category> GetCategories()
    {
        return _context
            .Categories
            .ToList();
    }

    public async Task<ICollection<Category>> GetCategoriesAsync()
    {
        return await _context
            .Categories
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryById(Guid id) 
    {
        return await _context
            .Categories
            .Where(category => category.Id == id)
            .SingleOrDefaultAsync();
    }

    public async void AddCategory(Category category)
    {
        await _context
            .Categories
            .AddAsync(category);
    }

    public void UpdateCategory(Category category)
    {
        _context
            .Categories
            .Update(category);
    }

    public void RemoveCategory(Category category)
    {
        _context
            .Categories
            .Remove(category);
    }
}
