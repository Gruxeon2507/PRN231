using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment02.Models;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace Assignment02.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalFacilitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public MedicalFacilitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MedicalFacilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalFacility>>> GetMedicalFacilities([FromQuery] string? search)
        {
            IQueryable<MedicalFacility> query = _context.MedicalFacilities;

            // Apply search filter if search parameter is provided
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(m => m.FacilityName.Contains(search));
            }

            // Execute the query and return the results
            var medicalFacilities = await query.ToListAsync();
            return medicalFacilities;
        }

        // GET: api/MedicalFacilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalFacility>> GetMedicalFacility(int id)
        {
          if (_context.MedicalFacilities == null)
          {
              return NotFound();
          }
            var medicalFacility = await _context.MedicalFacilities.FindAsync(id);

            if (medicalFacility == null)
            {
                return NotFound();
            }

            return medicalFacility;
        }

        // PUT: api/MedicalFacilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalFacility(int id, MedicalFacility medicalFacility)
        {
            if (id != medicalFacility.FacilityId)
            {
                return BadRequest();
            }

            _context.Entry(medicalFacility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalFacilityExists(id))
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

        // POST: api/MedicalFacilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicalFacility>> PostMedicalFacility(MedicalFacility medicalFacility)
        {
          if (_context.MedicalFacilities == null)
          {
              return Problem("Entity set 'DataContext.MedicalFacilities'  is null.");
          }
            _context.MedicalFacilities.Add(medicalFacility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalFacility", new { id = medicalFacility.FacilityId }, medicalFacility);
        }

        // DELETE: api/MedicalFacilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalFacility(int id)
        {
            if (_context.MedicalFacilities == null)
            {
                return NotFound();
            }
            var medicalFacility = await _context.MedicalFacilities.FindAsync(id);
            if (medicalFacility == null)
            {
                return NotFound();
            }

            _context.MedicalFacilities.Remove(medicalFacility);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("query")]
        public async Task<ActionResult<IEnumerable<MedicalFacility>>> QueryMedicalFacilities(int? level, bool? isPrivate)
        {
            var query = _context.MedicalFacilities.AsQueryable();

            if (level.HasValue)
            {
                query = query.Where(m => m.Level == level.Value);
            }

            if (isPrivate.HasValue)
            {
                query = query.Where(m => m.PrivateFacility == isPrivate.Value);
            }

            return await query.ToListAsync();
        }

        [HttpGet("export/csv")]
        public async Task<IActionResult> ExportToCsv()
        {
            var facilities = await _context.MedicalFacilities.ToListAsync();

            var csv = new StringBuilder();
            csv.AppendLine("FacilityId,FacilityName,NoDoctors,NoStaffs,PrivateFacility,Level");

            foreach (var facility in facilities)
            {
                csv.AppendLine($"{facility.FacilityId},{facility.FacilityName},{facility.NoDoctors},{facility.NoStaffs},{facility.PrivateFacility},{facility.Level}");
            }

            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", "MedicalFacilities.csv");
        }

        [HttpGet("classify")]
        public async Task<IActionResult> ClassifyFacilities()
        {
            var facilities = await _context.MedicalFacilities.ToListAsync();
            var classifiedFacilities = facilities.Select(f => new
            {
                f.FacilityId,
                f.FacilityName,
                Classification = (f.NoDoctors + f.NoStaffs) switch
                {
                    >= 50 => "Large",
                    >= 20 => "Medium",
                    _ => "Small"
                }
            });

            return Ok(classifiedFacilities);
        }



        private bool MedicalFacilityExists(int id)
        {
            return (_context.MedicalFacilities?.Any(e => e.FacilityId == id)).GetValueOrDefault();
        }
    }
}
