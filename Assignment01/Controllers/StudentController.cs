using Assignment01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment01.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UniversityContext _context;
        public StudentController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var us = _context.Students.ToList();
            if (us == null)
            {
                return NotFound();
            }

            return Ok(us);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = student.StudentCode }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Student student)
        {
            if (id != student.StudentCode)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Students.Any(e => e.StudentCode == id))
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
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("average")]
        public async Task<IActionResult> GetStudentsWithAverageScore([FromQuery] decimal minAverageScore = 1)
        {
            var studentsWithAverageScore = await _context.Students
                .Select(s => new
                {
                    StudentCode = s.StudentCode,
                    FullName = s.FullName,
                    DateOfBirth = s.DateOfBirth,
                    Gender = s.Gender,
                    AverageScore = _context.Transcripts
                        .Where(t => t.StudentCode == s.StudentCode)
                        .Average(t => t.HighestScore)
                })
                .Where(s => s.AverageScore >= minAverageScore)
                .ToListAsync();

            if (studentsWithAverageScore == null || studentsWithAverageScore.Count == 0)
            {
                return NotFound();
            }

            return Ok(studentsWithAverageScore);
        }
        [HttpGet("/top")]
        public async Task<IActionResult> GetTopStudents()
        {
            var topMaleStudent = await _context.Students
                .Where(s => s.Gender == 'M')
                .Select(s => new
                {
                    StudentCode = s.StudentCode,
                    FullName = s.FullName,
                    AverageScore = _context.Transcripts
                        .Where(t => t.StudentCode == s.StudentCode)
                        .Average(t => t.HighestScore)
                })
                .OrderByDescending(s => s.AverageScore)
                .FirstOrDefaultAsync();

            var topFemaleStudent = await _context.Students
                .Where(s => s.Gender == 'F')
                .Select(s => new
                {
                    StudentCode = s.StudentCode,
                    FullName = s.FullName,
                    AverageScore = _context.Transcripts
                        .Where(t => t.StudentCode == s.StudentCode)
                        .Average(t => t.HighestScore)
                })
                .OrderByDescending(s => s.AverageScore)
                .FirstOrDefaultAsync();

            if (topMaleStudent == null || topFemaleStudent == null)
            {
                return NotFound();
            }

            return Ok(new { TopMaleStudent = topMaleStudent, TopFemaleStudent = topFemaleStudent });
        }
    }
}
