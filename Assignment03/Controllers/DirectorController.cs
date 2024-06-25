using Assignment03.DTO;
using Assignment03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly PE_PRN_Fall22B1Context _context;

        public DirectorController(PE_PRN_Fall22B1Context context)
        {
            _context = context;
        }

        [HttpGet("GetDirectors/{nationality}/{gender}")]

        public IActionResult GetDirectors(string nationality, string gender)
        {
            var isMale = string.Equals(gender, "male", StringComparison.OrdinalIgnoreCase);
            var res = _context.Directors
                .Where(x => x.Nationality == nationality.ToLower()
                            && x.Male == isMale)
                .ToList();

            if (!res.Any())
            {
                return NotFound();
            }

            var result = res.Select(x => new
            {
                Id = x.Id,
                FullName = x.FullName,
                Gender = x.Male ? "Male" : "Female",
                Dob = x.Dob,
                DobString = x.Dob.ToString("M/d/yyyy"),
                Nationality = x.Nationality,
                Description = x.Description
            });

            return Ok(result);
        }

        [HttpGet("GetDirectors/{id}")]
        public IActionResult GetDirector(int id)
        {
            var director = _context.Directors
                .Include(d => d.Movies)
                    .ThenInclude(m => m.Producer)
                .FirstOrDefault(d => d.Id == id);

            if (director == null)
            {
                return NotFound();
            }

            var directorDTO = new DirectorDTO
            {
                Id = director.Id,
                FullName = director.FullName,
                Description = director.Description,
                Dob = director.Dob,
                DobString = director.Dob.ToString("M/d/yyyy"),
                Nationality = director.Nationality,
                Gender = director.Male ? "Male" : "Female",
                Movies = director.Movies.Select(movie => new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    DirectorId = movie.DirectorId,
                    DirectorName = movie.Director?.FullName, 
                    ProducerId = movie.ProducerId,
                    ProducerName = movie.Producer?.Name,
                    Language = movie.Language,
                    ReleaseDate = movie.ReleaseDate,
                    ReleaseYear = movie.ReleaseDate?.Year,
                    Genres = movie.Genres,
                    Stars = movie.Stars,
                }).ToList()
            };

            return Ok(directorDTO);
        }

        [HttpPost("Create")]
        public IActionResult Create(DirectorRequest request)
        {
            // Validate request
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Nationality) ||
                !DateTime.TryParse(request.Dob, out DateTime dob))
            {
                return BadRequest("Invalid input data.");
            }

            try
            {
                var director = new Director()
                {
                    FullName = request.FullName,
                    Description = request.Description,
                    Dob = dob,
                    Nationality = request.Nationality,
                    Male = request.Male
                };

                _context.Directors.Add(director);
                _context.SaveChanges();

                var response = new DirectorDTO()
                {
                    Id = director.Id,
                    FullName = director.FullName,
                    Description = director.Description,
                    Dob = director.Dob,
                    DobString = director.Dob.ToString("M/d/yyyy"),
                    Nationality = director.Nationality,
                    Gender = director.Male ? "Male" : "Female"
                };

                return CreatedAtAction(nameof(GetDirector), new { id = director.Id }, response);
            }
            catch (Exception ex)
            {
                return Conflict("There was an error while adding.");
            }
        }


    }
}
