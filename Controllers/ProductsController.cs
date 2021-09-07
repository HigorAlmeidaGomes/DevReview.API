using AutoMapper;
using DevReview.API.Entities;
using DevReview.API.Models;
using DevReview.API.Persistence.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevReview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _repository;

        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();

            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productsReview = await _repository.GetDetaisByIdAsync(id);

            if (productsReview == null) NotFound();

            var productDetails = _mapper.Map<ProductDetailsViewModel>(productsReview);

            return Ok(productDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddProductInputModel model)
        {
            var products = new Product(model.Title, model.Description, model.Price);

            await _repository.AddAsync(products);

            return CreatedAtAction(nameof(GetById), new { products.Id }, model);
        }

        //Put para api//product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductModel model)
        {
            if (model.Description.Length > 50) return BadRequest();

            var product = await _repository.GetByIdAsync(id);

            if (product == null) NotFound();

            product.Update(model.Price, model.Description);

            await _repository.UpdateAsync(product);

            return NoContent();
        }
    }
}