using Microsoft.AspNetCore.Mvc;
using NaijaCartApi.EntityFramework;
using NaijaCartApi.Models;

namespace NaijaCart.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly NaijaCartContext _context;

        public CustomerController(NaijaCartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customers = _context.Customers.ToList();
            if (!customers.Any())
                return NotFound();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return BadRequest();
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Created("", customer);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] Customer customerUpdate)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return BadRequest();
            customer = customerUpdate;
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var product = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return BadRequest();
            _context.Customers.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
