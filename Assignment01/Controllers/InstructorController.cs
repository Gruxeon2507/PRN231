using Assignment01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment01.Controllers
{
    [Route("api/instructor")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly UniversityContext _context;
        public InstructorController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            //var us = _context.Instructors.Include(i => i.InstructorSubjects).ThenInclude(i => i.Subject).ToList();
            var us = _context.Instructors.ToList();
            if (us == null)
            {
                return NotFound();
            }

            return Ok(us);
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = instructor.TeacherCode }, instructor);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Instructor instructor)
        {
            if (id != instructor.TeacherCode)
            {
                return BadRequest();
            }

            _context.Entry(instructor).State = EntityState.Modified;

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
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
