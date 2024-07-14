using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Q1.DTO;
using Q1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Q1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PE_PRN_24SumB1Context _context;

        private readonly IConfiguration _configuration;
        public UserController(PE_PRN_24SumB1Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpGet("")]

        public IActionResult GetUsers()
        {
            List<User> users = _context.Users.ToList();
            List<UserDTO> res = new List<UserDTO>();
            List<int> s = new List<int>();

            foreach (User u in users)
            {
                List<Enrollment> ue = _context.Enrollments.Where(e => e.UserId == u.UserId).ToList();
                List<CoursesDTO> c = new List<CoursesDTO>();

                foreach (Enrollment e in ue)
                {
                    CoursesDTO t = new CoursesDTO();
                    Course t1 = _context.Courses.Where(c => c.CourseId == e.CourseId).FirstOrDefault();
                    t.enrolledDate = e.EnrolledDate;
                    t.courseTitle = t1.Title;
                    t.courseId = t1.CourseId;
                    c.Add(t);
                }

                UserDTO us = new UserDTO();
                {
                    us.userId = u.UserId;
                    us.username = u.Username;
                    us.email = u.Email;
                    us.courses = c;
                }
                res.Add(us);
            }

            return Ok(res);
        }

        [HttpGet("{id}")]

        public IActionResult GetUsers(int id)
        {
            User u = _context.Users.Where(u => u.UserId == id).FirstOrDefault();
   
                List<Enrollment> ue = _context.Enrollments.Where(e => e.UserId == u.UserId).ToList();
                List<CoursesDTO> c = new List<CoursesDTO>();

                foreach (Enrollment e in ue)
                {
                    CoursesDTO t = new CoursesDTO();
                    Course t1 = _context.Courses.Where(c => c.CourseId == e.CourseId).FirstOrDefault();
                    t.enrolledDate = e.EnrolledDate;
                    t.courseTitle = t1.Title;
                    t.courseId = t1.CourseId;
                    c.Add(t);
                }

                UserDTO us = new UserDTO();
                {
                    us.userId = u.UserId;
                    us.username = u.Username;
                    us.email = u.Email;
                    us.courses = c;
                }

            return Ok(us);
        }

        [HttpPost("/api/login")]

        public IActionResult Login([FromBody] LoginModel login)
        {
            User u = _context.Users.Where(u => u.Username == login.Username && u.Password == login.Password).FirstOrDefault();
            if (u != null)
            {
                var token = GenerateJwtToken(login.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
