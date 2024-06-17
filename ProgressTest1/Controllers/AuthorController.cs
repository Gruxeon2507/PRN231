using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgressTest1.DTO;
using ProgressTest1.Models;

namespace ProgressTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase {
        private readonly DataContext _context;

        public AuthorController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var query = _context.Authors.ToList();



            return Ok(query);
        }
    }
}
