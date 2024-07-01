using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BE_thesis.Context;
using BE_thesis.Model;
using BE_thesis.InputModel;
using BE_thesis.Data;
using System.Drawing.Drawing2D;
using BE_thesis.Enum;
using Microsoft.AspNetCore.Authorization;
using BE_thesis.Filters;

namespace BE_thesis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{nameof(UserRole.Admin)},{nameof(UserRole.Manager)},{nameof(UserRole.Staff)}")]
    [Authorization]

    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", customers));

        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", customer));

            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", customer));

        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{customerId}")]
        public async Task<IActionResult> PutCustomer(int customerId, ApiCustomerInput customerInput)
        {
            if (customerId != customerInput.ID)
            {
                return BadRequest(ApiResponse.Instance.Response(StatusCodes.Status400BadRequest, "Bad Request", null));
            }

            var customer = _context.Customers.Find(customerId);
            if (customer == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

            }

            customer.Name = customerInput.Name ?? customer.Name;
            customer.Email = customerInput.Email ?? customer.Email;
            customer.Address = customerInput.Address ?? customer.Address;
            customer.Phone = customerInput.Phone ?? customer.Phone;

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CustomerExists(customerId))
                {
                    return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                      ApiResponse.Instance.Response(StatusCodes.Status500InternalServerError, ex.Message, null));
                }
            }

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", customer));

        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCustomer(ApiCustomerInput customerInput)
        {
            var newCustomer = new Customer();
            newCustomer.Name = customerInput.Name ?? "";
            newCustomer.Email = customerInput.Email ?? "";
            newCustomer.Address = customerInput.Address ?? "";
            newCustomer.Phone = customerInput.Phone ?? "";

            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", newCustomer));

        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(ApiResponse.Instance.Response(StatusCodes.Status404NotFound, "NotFound", null));

            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok(ApiResponse.Instance.Response(StatusCodes.Status200OK, "Success", customer));

        }
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.ID == id);
        }
    }
}
