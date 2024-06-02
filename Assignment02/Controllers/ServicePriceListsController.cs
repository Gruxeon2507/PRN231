using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment02.Models;

namespace Assignment02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePriceListsController : ControllerBase
    {
        private readonly DataContext _context;

        public ServicePriceListsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ServicePriceLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicePriceList>>> GetServicePriceLists([FromQuery] string? search)
        {
            IQueryable<ServicePriceList> query = _context.ServicePriceLists;

            // Apply search filter if search parameter is provided
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s => s.ServiceName.Contains(search));
            }

            // Execute the query and return the results
            var servicePriceLists = await query.ToListAsync();
            return servicePriceLists;
        }


        // GET: api/ServicePriceLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicePriceList>> GetServicePriceList(int id)
        {
          if (_context.ServicePriceLists == null)
          {
              return NotFound();
          }
            var servicePriceList = await _context.ServicePriceLists.FindAsync(id);

            if (servicePriceList == null)
            {
                return NotFound();
            }

            return servicePriceList;
        }

        // PUT: api/ServicePriceLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicePriceList(int id, ServicePriceList servicePriceList)
        {
            if (id != servicePriceList.ServiceId)
            {
                return BadRequest();
            }

            _context.Entry(servicePriceList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicePriceListExists(id))
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

        // POST: api/ServicePriceLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServicePriceList>> PostServicePriceList(ServicePriceList servicePriceList)
        {
          if (_context.ServicePriceLists == null)
          {
              return Problem("Entity set 'DataContext.ServicePriceLists'  is null.");
          }
            _context.ServicePriceLists.Add(servicePriceList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicePriceList", new { id = servicePriceList.ServiceId }, servicePriceList);
        }

        // DELETE: api/ServicePriceLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicePriceList(int id)
        {
            if (_context.ServicePriceLists == null)
            {
                return NotFound();
            }
            var servicePriceList = await _context.ServicePriceLists.FindAsync(id);
            if (servicePriceList == null)
            {
                return NotFound();
            }

            _context.ServicePriceLists.Remove(servicePriceList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicePriceListExists(int id)
        {
            return (_context.ServicePriceLists?.Any(e => e.ServiceId == id)).GetValueOrDefault();
        }
    }
}
