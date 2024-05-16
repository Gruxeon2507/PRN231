using Assignment01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorSubjectController : ControllerBase
    {
        private readonly UniversityContext _context;
        public InstructorSubjectController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var us = _context.InstructorSubjects.ToList();
            if (us == null)
            {
                return NotFound();
            }

            return Ok(us);
        }
        [HttpGet("{teacherCode}/{subjectCode}")]
        public async Task<IActionResult> Get(string teacherCode, string subjectCode)
        {
            var instructorSubject = await _context.InstructorSubjects.FindAsync(teacherCode, subjectCode);
            if (instructorSubject == null)
            {
                return NotFound();
            }

            return Ok(instructorSubject);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(InstructorSubject instructorSubject)
        {
            _context.InstructorSubjects.Add(instructorSubject);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { teacherCode = instructorSubject.TeacherCode, subjectCode = instructorSubject.SubjectCode }, instructorSubject);
        }

        [HttpPut("{teacherCode}/{subjectCode}")]
        public async Task<IActionResult> Update(string teacherCode, string subjectCode, InstructorSubject instructorSubject)
        {
            if (teacherCode != instructorSubject.TeacherCode || subjectCode != instructorSubject.SubjectCode)
            {
                return BadRequest();
            }

            _context.Entry(instructorSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.InstructorSubjects.Any(e => e.TeacherCode == teacherCode && e.SubjectCode == subjectCode))
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

        [HttpDelete("{teacherCode}/{subjectCode}")]
        public async Task<IActionResult> Delete(string teacherCode, string subjectCode)
        {
            var instructorSubject = await _context.InstructorSubjects.FindAsync(teacherCode, subjectCode);
            if (instructorSubject == null)
            {
                return NotFound();
            }

            _context.InstructorSubjects.Remove(instructorSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("teachers")]
        public async Task<IActionResult> GetTeachersBySubjectName(string? subjectName = null)
        {
            IQueryable<Instructor> teachersQuery = _context.Instructors;

            if (!string.IsNullOrWhiteSpace(subjectName))
            {
                // Filter by subject name if provided
                teachersQuery = teachersQuery.Where(i => i.InstructorSubjects.Any(isub => isub.Subject.SubjectName == subjectName));
            }

            var teachers = await teachersQuery.ToListAsync();

            if (teachers == null || teachers.Count == 0)
            {
                return NotFound();
            }

            return Ok(teachers);
        }
    }
}
