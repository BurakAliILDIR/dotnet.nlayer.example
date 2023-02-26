using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entity;
using NLayer.Core.Repository;



namespace NLayer.Repository.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int id)
        {
            return await _dbContext.Categories.Include(x => x.Products).Where(x => id == x.Id).SingleOrDefaultAsync();
        }
    }
}