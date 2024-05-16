using Assignment01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranscriptController : ControllerBase
    {
        private readonly UniversityContext _context;

        public TranscriptController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var us = _context.Transcripts.ToList();
            if (us == null)
            {
                return NotFound();
            }

            return Ok(us);
        }
        [HttpGet("{studentCode}/{subjectCode}")]
        public async Task<IActionResult> Get(string studentCode, string subjectCode)
        {
            var transcript = await _context.Transcripts.FindAsync(studentCode, subjectCode);
            if (transcript == null)
            {
                return NotFound();
            }

            return Ok(transcript);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(Transcript transcript)
        {
            _context.Transcripts.Add(transcript);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { studentCode = transcript.StudentCode, subjectCode = transcript.SubjectCode }, transcript);
        }

        [HttpPut("{studentCode}/{subjectCode}")]
        public async Task<IActionResult> Update(string studentCode, string subjectCode, Transcript transcript)
        {
            if (studentCode != transcript.StudentCode || subjectCode != transcript.SubjectCode)
            {
                return BadRequest();
            }

            _context.Entry(transcript).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Transcripts.Any(e => e.StudentCode == studentCode && e.SubjectCode == subjectCode))
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

        [HttpDelete("{studentCode}/{subjectCode}")]
        public async Task<IActionResult> Delete(string studentCode, string subjectCode)
        {
            var transcript = await _context.Transcripts.FindAsync(studentCode, subjectCode);
            if (transcript == null)
            {
                return NotFound();
            }

            _context.Transcripts.Remove(transcript);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("score")]
        public async Task<IActionResult> GetScoreList()
        {
            var scoreList = await _context.Transcripts
                .Include(t => t.Student)
                .Include(t => t.Subject)
                .Select(t => new
                {
                    StudentCode = t.Student.StudentCode,
                    FullName = t.Student.FullName,
                    Course = t.Student.Course,
                    SubjectName = t.Subject.SubjectName,
                    HighestScore = t.HighestScore
                })
                .ToListAsync();

            if (scoreList == null || scoreList.Count == 0)
            {
                return NotFound();
            }

            return Ok(scoreList);
        }
    }
}
