#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly weverMysqlContext _context;

        public CustomerController(weverMysqlContext context)
        {
            _context = context;
        }

        [EnableCors("CustomerPortalPolicy")]
        // GET: api/Customer/getcustomers
        [HttpGet("getcustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = _context.Customers.Select(c => new Customer { Id = c.User.Id, CompanyContactEmail = c.User.Email }).ToList();
            return customers;
        }

        [EnableCors("CustomerPortalPolicy")]
        // // GET: api/Customer/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        // {
        //     _context.Customers.Add(customer);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        // }

        // // DELETE: api/Customer/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteCustomer(long id)
        // {
        //     var customer = await _context.Customers.FindAsync(id);
        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Customers.Remove(customer);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
