using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Controllers
{
    [ApiController]
    [Route("api/controller")]

    public class UserController:ControllerBase
    {
        private readonly PRN221_MealManagementContext _context;
        public UserController(PRN221_MealManagementContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var us = _context.Users.ToList();   
            if(us==null)
            {
                return NotFound();
            }

            return Ok(us);
        }
    }
}
