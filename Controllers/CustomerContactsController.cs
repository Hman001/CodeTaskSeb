using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeTaskSeb.Models;

namespace CodeTaskSeb.Controllers
{
    [Route("api/CustomerContacts")]
    [ApiController]
    public class CustomerContactsController : ControllerBase
    {
        private readonly CodeTaskSebContext _context;

        public CustomerContactsController(CodeTaskSebContext context)
        {
            _context = context;
        }

        // GET: api/CustomerContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerContact>>> GetContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/CustomerContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerContact>> GetCustomerContact(int id)
        {
            var customerContact = await _context.Contacts.FindAsync(id);

            if (customerContact == null)
            {
                return NotFound();
            }

            return customerContact;
        }

        // PUT: api/CustomerContacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerContact(int id, CustomerContact customerContact)
        {
            if (id != customerContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerContacts
        [HttpPost]
        public async Task<ActionResult<CustomerContact>> PostCustomerContact(CustomerContact customerContact)
        {
            _context.Contacts.Add(customerContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomerContact), new { id = customerContact.Id }, customerContact);
        }

        // DELETE: api/CustomerContacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerContact(int id)
        {
            var customerContact = await _context.Contacts.FindAsync(id);
            if (customerContact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(customerContact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
