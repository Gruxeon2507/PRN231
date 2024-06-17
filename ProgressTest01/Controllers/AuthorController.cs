using Microsoft.AspNetCore.Mvc;
using ProgressTest01.Interfaces;

namespace ProgressTest01.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        //Api lấy ra tất cả các tác giả
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepo.GetAllAsync();
            if (authors == null)
            {
                return NotFound();
            }
            return Ok(authors);
        }
    }
}
