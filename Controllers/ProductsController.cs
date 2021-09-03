using AutoMapper;
using DevReview.API.Entities;
using DevReview.API.Models;
using DevReview.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DevReview.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DevReviewsDbContext _dbContext;

        private readonly IMapper _mapper;

        public ProductsController(DevReviewsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _dbContext.products;

            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var products = _dbContext.products.SingleOrDefault(x => x.Id == id);

            var productDetails = _mapper.Map<ProductDetailsViewModel>(products);
        
            if (productDetails == null) NotFound();
            return Ok(productDetails);
        }

        [HttpPost]
        public IActionResult Post(AddProductInputModel model)
        {
            // Se tiver erro na valida��o retonar BadRequest()
            var products = new Product(model.Title, model.Description, model.Price);

            _dbContext.products.Add(products);
            return CreatedAtAction(nameof(GetById), new { products.Id }, model);
        }

        //Put para api//product/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProductModel model)
        {
            //Se tiver erros de valida��es retornar BadRequest()
            //Se n�o existir produto com id especificado, retonar NotFound();
            if (model.Description.Length > 50) return BadRequest();

            var product = _dbContext.products.SingleOrDefault(x => x.Id == id);

            if (product == null) NotFound();

            product.Update(model.Price, model.Description);
            return NoContent();
        }
    }
}