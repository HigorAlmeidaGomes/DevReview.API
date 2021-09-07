using AutoMapper;
using DevReview.API.Entities;
using DevReview.API.Models;

namespace DevReview.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductReview, ProductReviewViewmModel>();
            CreateMap<ProductReview, ProductReviewDetailsViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, ProductDetailsViewModel>();
        }
    }
}