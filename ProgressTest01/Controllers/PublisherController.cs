using Microsoft.AspNetCore.Mvc;
using ProgressTest01.Interfaces;

namespace ProgressTest01.Controllers
{
    [ApiController]
    [Route("api/publisher")]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepo;

        public PublisherController(IPublisherRepository publisherRepo)
        {
            _publisherRepo = publisherRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var pubs = _publisherRepo.GetAllAsync();
            if (pubs == null)
            {
                return NotFound();
            }
            return Ok(pubs);
        }
    }
}
