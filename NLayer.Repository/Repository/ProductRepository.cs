using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entity;
using NLayer.Core.Repository;

namespace NLayer.Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<List<Product>> GetProductWithCategory()
        {
            // Eager Loading yapıldı. Kategorileri en başta çektiği için.
            return await _dbContext.Products.Include(x => x.Category).ToListAsync();
        }
    }
}