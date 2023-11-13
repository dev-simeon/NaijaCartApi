using Microsoft.AspNetCore.Mvc;
using NaijaCartApi.EntityFramework;
using NaijaCartApi.Models;

namespace NaijaCart.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly NaijaCartContext _context;

        public ProductController(NaijaCartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetProducts() 
        {
            var products = _context.Products.ToList();
            if (!products.Any())
                return NotFound();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult GetSingleProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return BadRequest();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Created("", product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, [FromBody] Product productUpdate)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return BadRequest();
            product = productUpdate;
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);
            if(product == null)
                return BadRequest();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
