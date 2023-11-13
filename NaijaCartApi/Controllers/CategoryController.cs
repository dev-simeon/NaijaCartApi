using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NaijaCartApi.EntityFramework;
using NaijaCartApi.Models;

namespace NaijaCart.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoryController : ControllerBase
    {
        private readonly NaijaCartContext _context;

        public CategoryController(NaijaCartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            if (!categories.Any())
                return NotFound();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult GetCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return BadRequest();
            return Ok(category);
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Created("", category);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] Category categoryUpdate)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return BadRequest();
            category = categoryUpdate;
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return BadRequest();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
