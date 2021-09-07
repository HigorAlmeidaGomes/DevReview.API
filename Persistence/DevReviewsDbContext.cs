using DevReview.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevReview.API.Persistence
{
    public class DevReviewsDbContext : DbContext
    {
        public DevReviewsDbContext(DbContextOptions<DevReviewsDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductReview> ProductsReview { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>
                (
                    x =>
                    {
                        x.ToTable("TB_PRODUCT"); 
                        x.HasKey(x => x.Id);
                        x.HasMany(x => x.Reviews).WithOne().HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
                    });
            
            modelBuilder.Entity<ProductReview>
                (
                    y =>
                    {
                        y.ToTable("TB_PRODUCT_REVIEW");
                        y.HasKey(y => y.Id);
                        y.Property(y => y.Author).IsRequired().HasMaxLength(50);
                    });
        }
    }
}
