using DevReview.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReview.API.Controllers
{
    [ApiController]
    [Route("api/products/{productId}/productreview")]
    public class ProductReviewController : ControllerBase
    {
        //Get api/product/1/productreview/5
        [HttpGet("{id}")]
        public IActionResult GetById(int productId, int id) 
        {
            //se não existir com o id especificado, retonrar notFound()
            return Ok();
        }

        //POST api/Productreviews
        [HttpPost]
        public IActionResult Post(int productId, AddProductReviewInputModel model) 
        {
            //Se tiver com dados invalidas retonar BadRequest
            return CreatedAtAction(nameof(GetById), new { id = 1, productId = 2 }, model);
        }

    }
}
