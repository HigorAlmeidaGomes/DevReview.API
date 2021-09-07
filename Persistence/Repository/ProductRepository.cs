using DevReview.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReview.API.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DevReviewsDbContext _dbContext;

        public ProductRepository(DevReviewsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddReviewAsync(ProductReview productReview)
        {
            await _dbContext.ProductsReview.AddAsync(productReview);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Product> GetDetaisByIdAsync(int id)
        {
           return await _dbContext.Products.Include(x => x.Reviews).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductReview> GetReviewByIdAsync(int id)
        {
           return await _dbContext.ProductsReview.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
