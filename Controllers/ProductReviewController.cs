using AutoMapper;
using DevReview.API.Entities;
using DevReview.API.Models;
using DevReview.API.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevReview.API.Controllers
{
    [ApiController]
    [Route("api/Products/{productId}/productreview")]
    public class ProductReviewController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductReviewController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //Get api/product/1/productreview/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, int id)
        {
            var productsReview = _repository.GetReviewByIdAsync(id);

            if (productsReview == null) return NotFound();

            var productDetails = _mapper.Map<ProductReviewDetailsViewModel>(productsReview);

            return Ok(productDetails);
        }

        //POST api/Productreviews
        [HttpPost]
        public async Task<IActionResult> Post(int productId, AddProductReviewInputModel model)
        {
            var productReview = new ProductReview(model.Author, model.Rating, model.Comments, productId);

            await _repository.AddReviewAsync(productReview);

            return CreatedAtAction(nameof(GetById), new { productReview.Id, productId = productId }, model); ;
        }

    }
}
