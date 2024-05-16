using Assignment01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment01.Controllers
{
    [ApiController]
    [Route("api/subject")]
    public class SubjectController: ControllerBase
    {
        private readonly UniversityContext _context;

        public SubjectController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var us = _context.Subjects.ToList();
            if (us == null)
            {
                return NotFound();
            }

            return Ok(us);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = subject.SubjectCode }, subject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Subject subject)
        {
            if (id != subject.SubjectCode)
            {
                return BadRequest();
            }

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Subjects.Any(e => e.SubjectCode == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
