using DevReview.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReview.API.Persistence.Repository
{
    public interface IProductRepository
    {

        Task AddAsync(Product product);

        Task<Product> GetDetaisByIdAsync(int id);

        Task<Product> GetByIdAsync(int id);

        Task<List<Product>> GetAllAsync();

        Task UpdateAsync(Product product);

        Task<ProductReview> GetReviewByIdAsync(int id);

        Task AddReviewAsync(ProductReview productReview);

    }
}
