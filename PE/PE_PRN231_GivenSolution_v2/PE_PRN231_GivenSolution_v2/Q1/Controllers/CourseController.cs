using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly PE_PRN_24SumB1Context _context;

        public CourseController(PE_PRN_24SumB1Context context)
        {
            _context = context;
        }
        [HttpDelete("{cid}/{uid}")]

        public IActionResult GetDirectors(int cid, int uid)
        {
            try
            {
                Enrollment e = _context.Enrollments.Where(e => e.UserId == uid && e.CourseId == cid).FirstOrDefault();
                if (e == null)
                {
                    return NoContent();
                }

                _context.Enrollments.Remove(e);
                _context.SaveChanges();

                return Ok();
            }catch(Exception e)
            {
                return Conflict();
            }
            
        }
    }
}
