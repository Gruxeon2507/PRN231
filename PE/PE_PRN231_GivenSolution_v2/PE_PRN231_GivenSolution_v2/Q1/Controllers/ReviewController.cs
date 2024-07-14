using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q1.DTO;
using Q1.Models;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly PE_PRN_24SumB1Context _context;

        public ReviewController(PE_PRN_24SumB1Context context)
        {
            _context = context;
        }

        [HttpGet("User/{id}")]
        [Authorize]
        public IActionResult GetReviews(int id)
        {
            List<Review> rs = _context.Reviews.Include( r => r.Course).Where(u => u.UserId == id).ToList();
            List<ReviewDTO> res = new List<ReviewDTO>();
            foreach(Review r in rs)
            {
                ReviewDTO t = new ReviewDTO();
                {
                    t.title = r.Course.Title;
                    t.reviewText = r.ReviewText;
                    t.reviewDate = r.ReviewDate;
                    t.rating = r.Rating;
                    t.courseId = r.CourseId;
                };
                res.Add(t);
            }

            return Ok(res);
        }
    }
}
