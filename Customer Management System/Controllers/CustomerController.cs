using Customer_Management_System.Data;
using Customer_Management_System.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
                

            return Ok(customer);
        }

       
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = await _context.Customers.FindAsync(id);

            if (existingCustomer == null)
            {
                return NotFound();
            }
               

            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;

            await _context.SaveChangesAsync();

            return Ok(existingCustomer);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }
         
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok("Customer deleted successfully");
        }
    }
}
